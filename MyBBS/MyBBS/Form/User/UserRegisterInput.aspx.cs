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


namespace MyBBS.Form.User
{
    public partial class UserRegisterInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        /// <summary>
        /// 会員登録ボタンを押した際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            if(InsertUser())
            {
                btnRegister.Text = "done";
            }
            // 確認画面へ遷移する
            btnRegister.Enabled = false;
            
        }

        /// <summary>
        /// ログインユーザを登録する
        /// </summary>
        /// <returns></returns>
        private bool InsertUser()
        {
            using (var accessor = new SqlAccessor())
            using (var statement = new SqlStatement("BBSUser", "Insert"))
            {
                var ht = new Hashtable
            {
                {BBSConst.SQL_PRAM_LOGIN_ID, inpLoginId.Value},
                {BBSConst.SQL_PRAM_PASSWORD, inpPassword.Value},
                {BBSConst.SQL_PRAM_USER_NAME, inpUserName.Value}

            };
                var result = statement.ExecStatementWithOC(accessor, ht);
                return (result > 0);
            }
        }
    }
}