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
        public const string SQL_PRAM_POST_TEXT = "PostText";

        public const string SQL_PRAM_THREAD_ID = "ThreadId";
        public const string SQL_PRAM_IS_DELETED = "IsDeleted";
        public const string SQL_PRAM_ORIGIN_THREAD_ID = "OriginThreadId";
        public const string SQL_PARAM_THREAD_FROM = "ThreadFrom";
        public const string SQL_PARAM_THREAD_TO = "ThreadTo";

        #endregion

        // Config メッセージ
        #region Config メッセージ
        public const string CONFIG_MSG_LOGINERROR = "LoginError";
        #endregion

        // Sessionメッセージ
        #region SESSION メッセージ
        public const string SESSION_NAME_USERID= "UserId";
        public const string SESSION_NAME_LOGINID = "LoginId";
        public const string SESSION_NAME_USER_NAME = "UserName";

        public const string SESSION_NAME_TEMP_USERID = "TempUserId";
        public const string SESSION_NAME_TEMP_LOGINID = "TempLoginId";
        public const string SESSION_NAME_TEMP_USER_NAME = "TempUserNAME";
        public const string SESSION_NAME_TEMP_PASSWORD = "TempPassword";

        #endregion

        // WebFormパス
        #region WEBFORM
        public const string WEB_FORM_BBS = "~/Form/BBS/BBS.aspx";
        public const string WEB_FROM_BBS_TOP = "~/Form/BBS/BBSTop.aspx";

        public const string WEB_FORM_USER_CONFIRM = "~/Form/User/UserRegisterConfirm.aspx";
        public const string WEB_FORM_USER_COMPLETE = "~/Form/User/UserRegisterComplete.aspx";

        public const string WEB_FORM_ERROR = "~/Form/Error.aspx";
        #endregion

        // Validate Group
        public const string VALIDATE_GROUP_REQIRED = "requiredGroup";
    }
}