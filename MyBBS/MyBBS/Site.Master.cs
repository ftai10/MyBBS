﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.Ajax.Utilities;

namespace MyBBS
{
    public partial class SiteMaster : MasterPage
    {

        /// <summary>
        /// 設定値よりConfigファイルの値を取得する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigMessage(string key)
        {
            var customMessageSettings = (NameValueCollection)ConfigurationManager.GetSection("CustomMessageSettings");
            return customMessageSettings[key];

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // ここでセッション管理できる？
            if (Session["UserId"] == null
                &&this.Page.AppRelativeVirtualPath != "~/Form/BBS/BBSTop.aspx")
            {
                
                Response.Redirect("~/Form/BBS/BBSTop.aspx");
            } 
            // トップページのリストコントロール
        }
    }
}