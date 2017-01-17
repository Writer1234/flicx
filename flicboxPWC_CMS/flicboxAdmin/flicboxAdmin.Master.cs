using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class flicboxAdmin : System.Web.UI.MasterPage
    {
        string key = "class", valueHeader = "active";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string url = this.Context.Request.RawUrl.ToString();
            url = url.Substring(url.LastIndexOf("/") + 1);

            AssignMenuCssStyle(url);

        }

        private void AssignMenuCssStyle(string _url)
        {
            switch (_url.ToLower().Trim())
            {
                case "dashboard.aspx":
                    lnkDashboard.Attributes.Add(key, valueHeader);
                    break;
                case "corporate-gifting-master.aspx":
                    lnkCorpGift.Attributes.Add(key, valueHeader);
                    break;
                case "contact-us-master.aspx":
                    lnkContactus.Attributes.Add(key, valueHeader);
                    break;
                case "plans-master.aspx?mode=1":
                    lnkPlans.Attributes.Add(key, valueHeader);
                    break;
                default:
                    break;
            }
        }
    }
}