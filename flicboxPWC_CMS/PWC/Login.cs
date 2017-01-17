using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace flicboxPWC_CMS.PWC
{
    public class Login
    {
        string strUsername = "", strUserId = "", strPassword = "";
        bool isLoginValid = false;

        XmlDocument objXmlDoc = new XmlDocument();

        public string UserId
        {
            get { return strUserId; }
            set { strUserId = value; }
        }

        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public bool Authenticate(string a_username, string a_password, System.Web.UI.Page a_page)
        {
            objXmlDoc.Load(a_page.Server.MapPath("~/App_Data/LoginDetails.xml").ToString());

            XmlNodeList objNodeList = objXmlDoc.GetElementsByTagName("user");

            for (int i = 0; i < objNodeList.Count; i++)
            {
                strUserId = objNodeList.Item(i).Attributes["id"].Value.ToString().Trim();
                strUsername = objNodeList.Item(i).ChildNodes[0].InnerText.ToString().Trim();
                strPassword = objNodeList.Item(i).ChildNodes[1].InnerText.ToString().Trim();

                if (strUsername.ToLower() == a_username.ToLower() && strPassword.Trim() == a_password.Trim())
                {
                    UserId = strUserId;
                    Username = strUsername;
                    Password = strPassword;
                    isLoginValid = true;
                    break;
                }
            }

            return isLoginValid;
        }

        public bool ChangePassword(string _userId, string _strPassword, System.Web.UI.Page _page)
        {
            try
            {
                objXmlDoc.Load(_page.MapPath("~/App_Data/LoginDetails.xml").ToString());

                string node = "Login/user";

                foreach (XmlElement element in objXmlDoc.SelectNodes(node))
                {
                    string attr = element.Attributes["id"].Value.ToString();

                    if (attr.ToLower().Trim() == _userId.ToLower().Trim())
                    {
                        element.ChildNodes[1].InnerText = _strPassword.Trim();
                        break;
                    }
                }
                objXmlDoc.Save(_page.Server.MapPath("~/App_Data/LoginDetails.xml").ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}