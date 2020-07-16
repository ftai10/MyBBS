using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBBS.Util;

namespace MyBBS.Form.BBS
{
    public partial class BBS : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ltName.Text = Session[BBSConst.SESSION_NAME_LOGINID].ToString() ;
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {

        }

        protected void rptBBS_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btPost_Click(object sender, EventArgs e)
        {

        }
    }
}