using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (true)
            {
                lerrorMessage.Text = Master.GetConfigMessage("LoginError");
                // Go to BBS
                //Response.Redirect("BBS.aspx");
            }
            else
            {
                // Show Error Message
                lerrorMessage.Text = "ログインに失敗しました。";
            }
            
        }
    }
}