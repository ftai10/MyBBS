using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBBS.Util
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            // 有効なセッションがなく、セッションが必要なパスにアクセスした場合は、トップにリダイレクト
            if (Session[BBSConst.SESSION_NAME_USERID] == null &&
                this.NonSessionPahts().Contains(this.Page.AppRelativeVirtualPath) == false)
            {

                Response.Redirect("~/Form/BBS/BBSTop.aspx");
            }
        }

        /// <summary>
        /// セッション不要なパスを定義する
        /// </summary>
        /// <returns></returns>
        private List<string> NonSessionPahts()
        {
            return new List<string> {
                                     "~/Form/BBS/BBSTop.aspx",
                                     "~/Form/User/UserRegisterInput.aspx"
                                    };
        }

    }
}