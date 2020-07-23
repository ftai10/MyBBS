using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using w2.Common.Sql;
using MyBBS.Util;
using System.Web.UI.HtmlControls;

namespace MyBBS.Form.User
{
    public partial class UserRegisterInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //ページ名の設定
                ltPageTitle.Text += Session[BBSConst.SESSION_NAME_USERID] == null? "登録" : "編集";
            }
        }

        /// <summary>
        /// 会員登録ボタンを押した際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Vaild
            Validate(BBSConst.VALIDATE_GROUP_REQIRED);

            if (Page.IsValid) {

                // 入力値の設定
                Session[BBSConst.SESSION_NAME_TEMP_USER_NAME] = inpUserName.Value;
                Session[BBSConst.SESSION_NAME_TEMP_LOGINID] = inpLoginId.Value;
                Session[BBSConst.SESSION_NAME_TEMP_PASSWORD] = inpPassword.Value;

                // 確認画面へ遷移する
                Response.Redirect(BBSConst.WEB_FORM_USER_CONFIRM);
            }

        }
    }
}