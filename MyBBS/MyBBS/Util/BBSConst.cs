using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBBS.Util
{
    /// <summary>
    ///　定数を定義するクラス
    /// </summary>
    public class BBSConst
    {
        // SQLパラメータ
        #region SQLパラメータ
        public const string SQL_PRAM_LOGIN_ID = "LoginId";
        public const string SQL_PRAM_USER_ID = "UserId";
        public const string SQL_PRAM_PASSWORD = "Password";
        public const string SQL_PRAM_USER_NAME = "UserName";
        public const string SQL_PRAM_TITLE = "Title";
        #endregion

        // Config メッセージ
        #region Config メッセージ
        public const string CONFIG_MSG_LOGINERROR = "LoginError";
        #endregion

        // Sessionメッセージ
        #region SESSION メッセージ
        public const string SESSION_NAME_USERID= "UserId";
        public const string SESSION_NAME_LOGINID = "LoginId";

        #endregion

        // WebFormパス
        #region WEBFORM
        public const string WEB_FORM_BBS = "~/Form/BBS/BBS.aspx";
        #endregion
    }
}