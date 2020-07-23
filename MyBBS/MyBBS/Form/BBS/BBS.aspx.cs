using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MyBBS.Util;
using w2.Common;
using w2.Common.Sql;

namespace MyBBS.Form.BBS
{
    public partial class BBS : BasePage
    {
        private int threadPerPage = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // ページング番号をGetParameterより取得
                string pnoStr = Request.QueryString["pno"];

                // LoadThread
                int pno;
                rptBBS.DataSource = Get(int.TryParse(pnoStr, out pno)? pno : 1 );
                rptBBS.DataBind();

                // ページングリンクの制御
                if (pno <= 1)
                {
                    linkPreviousThread.Enabled = false;
                }

                if (rptBBS.Items.Count < threadPerPage)
                {
                    linkNextThread.Enabled = false;
                }
                
            }
        }

        /// <summary>
        /// 掲示板データ取得時のデータ表示処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptBBS_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var view = (DataRowView)e.Item.DataItem;

                ((HtmlGenericControl)e.Item.FindControl("threadArea")).Attributes["class"] = bool.Parse(view["isOrigin"].ToString()) ? "Origin" : "Res";

                // 投稿者か否かによって編集ボタンの表示を制御する
                ((LinkButton)e.Item.FindControl("linkEdit")).Visible = Session[BBSConst.SESSION_NAME_USERID].ToString() == view["UserId"].ToString() ? true : false;
                ((LinkButton)e.Item.FindControl("linkRes")).Visible = bool.Parse(view["isOrigin"].ToString()) ? true : false;

            }
        }

        /// <summary>
        /// フォームの投稿を実施する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btPost_Click(object sender, EventArgs e)
        {
            if (UpsertThread())
            {
                // 登録が成功したリダイレクトし設定値を初期化する
                Response.Redirect(BBSConst.WEB_FORM_BBS + "?pno=" + (int.Parse(hdnPageNo.Value)).ToString());

            }

            throw new w2Exception("掲示板登録処理でエラーが発生しました");
        }

        /// <summary>
        /// フォームの編集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editBtn_Click(object sender, EventArgs e)
        {
            this.btPost_Click(sender, e);

        }

        /// <summary>
        /// フォームの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btDel_Click(object sender, EventArgs e)
        {
            // 削除フラグを有効にする
            hdnIsDeleteFlg.Value = "1";

            this.btPost_Click(sender, e);
        }

        private DataView Get(int pno)
        {
            // ページ番号をクラス内で管理する
            hdnPageNo.Value = pno.ToString();

            using (var accessor = new SqlAccessor())
            using (var statement = new SqlStatement("Thread", "Get"))
            {
                var ht = new Hashtable
            {
                {BBSConst.SQL_PARAM_THREAD_FROM, (pno-1) * threadPerPage},
                {BBSConst.SQL_PARAM_THREAD_TO, pno * threadPerPage}
            };
                var dv = statement.SelectSingleStatementWithOC(accessor, ht);
                return (dv.Count != 0) ? dv : null;
            }

        }

        /// <summary>
        /// 掲示板の登録更新処理を行う
        /// </summary>
        /// <returns></returns>
        private bool UpsertThread()
        {

            // 対象のテーブルはLOGINIDにユニークIndexを設定し重複を弾く
            using (var accessor = new SqlAccessor())
            using (var statement = new SqlStatement("Thread", "Upsert"))
            {
                var ht = new Hashtable
            {
                {BBSConst.SQL_PRAM_USER_ID, Session[BBSConst.SESSION_NAME_USERID].ToString()},
                {BBSConst.SQL_PRAM_TITLE, tbTitle.Text },
                {BBSConst.SQL_PRAM_POST_TEXT,tbPostText.Text },
                {BBSConst.SQL_PRAM_THREAD_ID, hdnTreadId.Value == "0" ? 0 : int.Parse(hdnTreadId.Value) },
                {BBSConst.SQL_PRAM_IS_DELETED, hdnIsDeleteFlg.Value == "0" ? 0 : 1 },
                {BBSConst.SQL_PRAM_ORIGIN_THREAD_ID, hdnOrigenTreadId.Value == "0" ? 0 : int.Parse(hdnOrigenTreadId.Value) }

            };

                var result = statement.ExecStatementWithOC(accessor, ht);
                return (result > 0);
            }
        }

        /// <summary>
        /// ログオフ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            // セッション情報を破棄
            Session.Clear();

            Response.Redirect(BBSConst.WEB_FROM_BBS_TOP);
        }

        /// <summary>
        /// リピーターコマンド
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptBBS_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            var hdnItemThreadId = (HiddenField)e.Item.FindControl("hdnTreadId");
            var itemTilte = (Literal)e.Item.FindControl("lttitle");

            // 更新の場合
            if (e.CommandName == "Edit") 
            {
                hdnTreadId.Value = hdnItemThreadId.Value;
                tbTitle.Text = HttpUtility.HtmlDecode(itemTilte.Text);

                var itemPostText = (HiddenField)e.Item.FindControl("hdnPostText");
                tbPostText.Text = HttpUtility.HtmlDecode(itemPostText.Value);

                btEdit.Visible = true;
                btDel.Visible = true;
                btPost.Visible = false;
            }
            // 返信の場合
            else if (e.CommandName == "Res")
            {
                hdnOrigenTreadId.Value = hdnItemThreadId.Value;
                tbTitle.Text = "[Re:]" + itemTilte.Text;

            }
        }

        protected void linkNextThread_Click(object sender, EventArgs e)
        {
            Response.Redirect(BBSConst.WEB_FORM_BBS + "?pno=" + (int.Parse(hdnPageNo.Value)+1).ToString());
        }

        protected void linkPreviousThread_Click(object sender, EventArgs e)
        {
            Response.Redirect(BBSConst.WEB_FORM_BBS + "?pno=" + (int.Parse(hdnPageNo.Value) - 1).ToString());
        }
    }
}