using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Configuration;
using System.IO;
using System.Web.SessionState;
using w2.Common;
using w2.Common.Logger;
using MyBBS.Util;
using System.Security.Policy;

namespace MyBBS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // アプリケーションのスタートアップで実行するコードです
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			Initialize();
        }

		/// <summary>
		/// アプリケーションの初期化
		/// </summary>
		private void Initialize()
		{
			Constants.APPLICATION_NAME = WebConfigurationManager.AppSettings["Application_Name"];
			Constants.STRING_SQL_CONNECTION = WebConfigurationManager.AppSettings["ConnectionString"];
			Constants.PHYSICALDIRPATH_LOGFILE = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
			Constants.PHYSICALDIRPATH_SQL_STATEMENT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Xml", "Db");
		}

		void Application_End(object sender, EventArgs e)
		{
		}


		/// <summary>
		/// ハンドルされていないエラーが発生したときに実行するコード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Application_Error(object sender, EventArgs e)
		{
			// 最後に発生したエラー原因情報をExceptionオブジェクトとして取得
			var error = Server.GetLastError();

			// ログ出力
			var errorPageInfo = w2.Common.Web.WebUtility.GetRawUrl(Request) + "   [" + Request.UserHostAddress + "] [" + w2.Common.Util.StringUtility.ToEmpty(Request.UserAgent) + "]";
			FileLogger.WriteError(errorPageInfo, error);

			// エラーページへ遷移する
			Response.Redirect(BBSConst.WEB_FORM_ERROR);
		}
	}
}