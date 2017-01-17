using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Web.UI;

namespace flicboxPWC_CMS.PWC
{
    public class Global :System.Object
    {
        public static string strUsername = "contact.prasad90@gmail.com", strPassword = "aai1990$";
        static string strErrorMsg = string.Empty;
        public string strTodayDate = string.Empty;

        public string CurrentDate
        {
            get { return strTodayDate; }
            set { strTodayDate = value; }
        }

        public static string SendMail(string _strSender, string _strRecipient, string _strSubject, string _strBody, bool _isBodyHtml, System.Web.UI.Page _page)
        {
            try
            {
                MailAddress objFromAddress = new MailAddress(_strSender);
                MailAddress objToAddress = new MailAddress(_strRecipient);

                MailMessage objMailMessage = new MailMessage(objFromAddress, objToAddress);
                objMailMessage.Subject = _strSubject.ToString();
                objMailMessage.Body = _strBody.ToString();
                objMailMessage.IsBodyHtml = _isBodyHtml;


                NetworkCredential objNetCredential = new NetworkCredential();
                objNetCredential.UserName = strUsername.ToString().Trim();
                objNetCredential.Password = strPassword.ToString().Trim();

                SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.EnableSsl = true;
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.Credentials = objNetCredential;
                objSmtpClient.Send(objMailMessage);

                strErrorMsg = "Submission is Successful !\\nWe will get in touch with you soon !";
                return strErrorMsg;
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message.ToString();
                WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "Global.SendMail()", _page);
                return strErrorMsg;
            }
        }

        /*Method is used to store the user's last visited page's url into as session varible*/
        public static void SetLastLocation(System.Web.UI.Page _page, HttpContext _context)
        {
            string strUrl = _context.Request.RawUrl.ToString().Trim();
            strUrl = strUrl.Substring(strUrl.LastIndexOf("/") + 1);
            _page.Session["LastLocation"] = strUrl.ToString().Trim();
        }

        /* Comments
         DisplayStatusDivision method - Created for displaying status messages after insert/update/delete/error
             param 1 - bool _status : value to check whether error/exception occurred or not
             param 2 - string _strMsg : display message label
             param 3 - Page _page : pass page instance
         */
        public static string DisplayStatusDivision(bool _status, string _strMsg, System.Web.UI.Page _page)
        {
            StringWriter stringWriter = new StringWriter();
            string strImgUrl = string.Empty, strColor = string.Empty;

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                if (_status)
                {
                    strImgUrl = "../images/icons/error.png";
                    strColor = "red";
                }
                else
                {
                    strImgUrl = "../images/icons/success.png";
                    strColor = "green";
                }

                writer.AddAttribute(HtmlTextWriterAttribute.Src, strImgUrl);
                writer.RenderBeginTag(HtmlTextWriterTag.Img);
                writer.RenderEndTag();

                writer.AddStyleAttribute(HtmlTextWriterStyle.Color, strColor);
                writer.RenderBeginTag(HtmlTextWriterTag.Label);
                writer.Write(" " + _strMsg.ToString());
                writer.RenderEndTag();

                string strGeneratedHTML = _page.Server.HtmlDecode(writer.InnerWriter.ToString());
                return strGeneratedHTML.Trim();
            }
        }

        public static void WriteErrorLog(string _errMsg, string _stackTrace, string _targetSite, string _methodName, System.Web.UI.Page _page)
        {
            string strLogFilePath = _page.Server.MapPath("~/App_Data/Log.txt");
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();

            if (File.Exists(strLogFilePath))
            {
                strBuilder.AppendLine("Error Date : " + DateTime.Now.ToString());
                strBuilder.AppendLine("Error Message : " + _errMsg);
                //strBuilder.AppendLine("Stack Trace : " + _stackTrace);
                strBuilder.AppendLine("Target Site : " + _targetSite);
                strBuilder.AppendLine("Method Name : " + _methodName);
                strBuilder.AppendLine();

                File.AppendAllText(strLogFilePath, strBuilder.ToString());
            }
        }
    }
}