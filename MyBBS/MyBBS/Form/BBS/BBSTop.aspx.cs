using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using w2.Common.Sql;
using w2.Common;
using System.IO;
using MyBBS.Util;

namespace MyBBS.Form.BBS
{
    public partial class BBSTop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
        }
        /// <summary>
        /// ログインボタンを押したときのログイン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // パラメータチェック

            // Refer DB
            var user = Get(inpLoginId.Value);

            if (user != null)
            {
                // セッション追加
                Session[BBSConst.SESSION_NAME_LOGINID] = user[BBSConst.SQL_PRAM_LOGIN_ID];
                Session[BBSConst.SESSION_NAME_USERID] = user[BBSConst.SQL_PRAM_USER_ID];

                // Go to BBS
                Response.Redirect(BBSConst.WEB_FORM_BBS);
            }
            else
            {
                // Show Error Message
                lerrorMessage.Text = Master.GetConfigMessage(BBSConst.CONFIG_MSG_LOGINERROR);
            }
        }

        /// <summary>
        /// ログイン処理時にユーザ情報を取得する
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        private DataRowView Get(string loginId)
        {
            using (var accessor = new SqlAccessor())
            using (var statement = new SqlStatement("BBSUser", "Get"))
            {
                var ht = new Hashtable
            {
                {BBSConst.SQL_PRAM_LOGIN_ID, inpLoginId.Value},
                {BBSConst.SQL_PRAM_PASSWORD, inpPassword.Value}
            };
                var dv = statement.SelectSingleStatementWithOC(accessor, ht);
                return (dv.Count != 0) ? dv[0] : null;
            }
        }

    }
}