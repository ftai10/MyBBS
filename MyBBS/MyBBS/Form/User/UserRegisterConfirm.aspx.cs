using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBBS.Util;
using w2.Common;
using w2.Common.Sql;

namespace MyBBS.Form.User
{
    public partial class UserRegisterConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ltUserName.Text = Session[BBSConst.SESSION_NAME_TEMP_USER_NAME].ToString();
                ltLoginId.Text = Session[BBSConst.SESSION_NAME_TEMP_LOGINID].ToString();

                // ユーザIDの有無に応じてユーザIDの設定を変更
                Session[BBSConst.SESSION_NAME_TEMP_USERID] = Session[BBSConst.SESSION_NAME_USERID] == null ?
                                                             Guid.NewGuid():
                                                             Session[BBSConst.SESSION_NAME_USERID];
            }
        }

        /// <summary>
        /// ユーザをDB登録する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (UpsertUser())
            {
                // 登録完了は自動ログインとみなし、ログイン状態のセッションを設定する
                Session[BBSConst.SESSION_NAME_USERID] = Session[BBSConst.SESSION_NAME_TEMP_USERID];
                Session[BBSConst.SESSION_NAME_LOGINID] = Session[BBSConst.SESSION_NAME_TEMP_LOGINID];
                Session[BBSConst.SESSION_NAME_USER_NAME] = Session[BBSConst.SESSION_NAME_TEMP_USER_NAME];

                // ユーザ登録処理に利用した一時情報は破棄する
                Session[BBSConst.SESSION_NAME_TEMP_USERID] = null;
                Session[BBSConst.SESSION_NAME_TEMP_USER_NAME] =  null;
                Session[BBSConst.SESSION_NAME_TEMP_LOGINID] = null;
                Session[BBSConst.SESSION_NAME_TEMP_PASSWORD] = null;

                // 登録が成功したら完了画面に遷移させる
                Response.Redirect(BBSConst.WEB_FORM_USER_COMPLETE);
            }

            // 会員登録処理が失敗する場合、無条件で例外とみなす
            throw new w2Exception("会員登録処理に失敗しました。");
        }

        /// <summary>
        /// ログインユーザを登録する
        /// </summary>
        /// <returns></returns>
        private bool UpsertUser()
        {

            // 対象のテーブルはLOGINIDにユニークIndexを設定し重複を弾く
            using (var accessor = new SqlAccessor())
            using (var statement = new SqlStatement("BBSUser", "Upsert"))
            {
                var ht = new Hashtable
            {
                {BBSConst.SQL_PRAM_USER_ID, Session[BBSConst.SESSION_NAME_TEMP_USERID].ToString() },
                {BBSConst.SQL_PRAM_LOGIN_ID, Session[BBSConst.SESSION_NAME_TEMP_LOGINID].ToString()},
                {BBSConst.SQL_PRAM_PASSWORD, Session[BBSConst.SESSION_NAME_TEMP_PASSWORD].ToString()},
                {BBSConst.SQL_PRAM_USER_NAME, Session[BBSConst.SESSION_NAME_TEMP_USER_NAME].ToString()}

            };
                var result = statement.ExecStatementWithOC(accessor, ht);
                return (result > 0);
            }
        }

    }
}