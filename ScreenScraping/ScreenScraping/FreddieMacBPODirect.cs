using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ScreenScraping
{
    public class FreddieMacBPODirect
    {
        private const string homePage = "https://www.bpodirect.com/";

        private const string loginURL = "https://www.bpodirect.com/pkmslogin.form";
        private const string logoffURL = "https://www.bpodirect.com/BPODirect1/onLogOff.do";

        private const string welcomePage = "https://www.bpodirect.com/BPODirect1/onWelcome.do";
        private const string newOrderPage = "https://www.bpodirect.com/start.do?bpo-begin=true";
        private const string pendingOrderPage = "https://www.bpodirect.com/pend.do?bpo-begin=true";
        private const string pastDueOrderPage = "https://www.bpodirect.com/past.do?bpo-begin=true";
        private const string onHoldOrderPage = "https://www.bpodirect.com/onPrepareOrdersVOResponse.do?bpo-begin=true&method=holdOrders";
        private const string moreOrderPage = "https://www.bpodirect.com/onPrepareOrdersVOResponse.do?bpo-begin=true&method=getMoreBPOs";
        
        private const string formFillPage = "https://www.bpodirect.com/BPODirect1/onForm.do?orderId={0}";
        private const string formFillURL = "https://www.bpodirect.com/BPODirect1/HSCFormTab{0}.do";
        private const string appraisalFormFillURL = "https://www.bpodirect.com/BPODirect1/onAppraisalForm.do";

        private const string uploadPhotoPage = "https://www.bpodirect.com/BPODirect1/work/uploadPhoto.do?orderId={0}";
        private const string uploadPhotoURL = "https://www.bpodirect.com/BPODirect1/work/uploadPhoto.do?orderId={0}";

        private const string searchOrderPage = "https://www.bpodirect.com/onPrepareOrdersVOResponse.do?bpo-begin=true&method=searchOrders";
        private const string searchOrderURL = "https://www.bpodirect.com/BPODirect1/onSearchOrders.do";

        private const string boundary = "---------------------------7dae91d710cd8";
        
        private string username = "sp129449";
        private string password = "NJ,&yNH5";
        
        private HttpRetriever bpoDirect = new HttpRetriever();
        
        #region Constructors

        public FreddieMacBPODirect()
        {
            // do not have anything to do here at the moment
        }

        #endregion

        #region Methods

        public string GetHomePage()
        {
            return GetPage(homePage);
        }

        public string GetLoginPage()
        {
            Dictionary<string, string> loginData = new Dictionary<string, string>();
            loginData.Add("username", string.Format("1{0}", username));
            loginData.Add("password", password);
            loginData.Add("login-form-type", "pwd");

            byte[] html = bpoDirect.Post(loginURL, loginData);
            return Encoding.UTF8.GetString(html);
        }

        public string GetLogoffPage()
        {
            return GetPage(logoffURL);
        }

        public string GetWelcomePage()
        {
            return GetPage(welcomePage);
        }

        public string GetNewOrderPage()
        {
            return GetPage(newOrderPage);
        }

        public string GetPendingOrderPage()
        {
            return GetPage(pendingOrderPage);
        }

        public string GetPastDueOrderPage()
        {
            return GetPage(pastDueOrderPage);
        }

        public string GetOnHoldOrderPage()
        {
            return GetPage(onHoldOrderPage);
        }

        public string GetMoreOrderPage()
        {
            return GetPage(moreOrderPage);
        }

        public string GetFormFillPage(string orderID)
        {
            return GetPage(string.Format(formFillPage, orderID));
        }

        public int GetBPOFormTabCount(string orderID)
        {
            string html = GetFormFillPage(orderID);

            Regex re = new Regex(@"javascript:doPost\((\d+)\)", RegexOptions.Multiline);
            if (re.IsMatch(html))
            {
                MatchCollection mc = re.Matches(html);
                List<int> list = new List<int>();
                foreach (Match m in mc)
                {
                    list.Add(int.Parse(m.Groups[1].Value));
                }

                if (list.Count > 0)
                    return list.Max();
            }

            return -1;
        }

        public string GoToBPOFormTab(string orderID, int tabNumber)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["orderIdentifierString"] = orderID;
            data["actionType"] = "get";
            data["goToTab"] = tabNumber.ToString();
            data["currentTab"] = tabNumber.ToString();
            data["formModified"] = "F";
            data["x"] = "1";
            data["y"] = "1";

            byte[] html = bpoDirect.Post(string.Format(formFillURL, tabNumber), data);
            return Encoding.UTF8.GetString(html);
        }
        
        public string SaveBPOFormTab(string orderID, int tabNumber, Dictionary<string, string> data)
        {
            data["orderIdentifierString"] = orderID;
            data["actionType"] = "save";
            data["goToTab"] = tabNumber.ToString();
            data["currentTab"] = tabNumber.ToString();
            data["formModified"] = "T";
            data["x"] = "1";
            data["y"] = "1";

            byte[] html = bpoDirect.Post(string.Format(formFillURL, tabNumber), data);
            return Encoding.UTF8.GetString(html);
        }

        public string SaveAppraisalForm(string orderID, Dictionary<string, string> data)
        {
            string updateTimeString = null;

            string html1 = GetFormFillPage(orderID);
            Regex re = new Regex("<input type=\"hidden\" name=\"updateTimeString\" value=\"([0-9]+)\">", RegexOptions.Multiline);
            if (re.IsMatch(html1))
            {
                updateTimeString = re.Match(html1).Groups[1].Value;
            }

            data["orderIdentifierString"] = orderID;
            data["actionType"] = "save";
            data["updateTimeString"] = updateTimeString;
            data["x"] = "1";
            data["y"] = "1";

            byte[] html = bpoDirect.Post(appraisalFormFillURL, data);
            return Encoding.UTF8.GetString(html);
        }

        public string GetUploadPhotoPage(string orderID)
        {
            return GetPage(string.Format(uploadPhotoPage, orderID));
        }

        public string[] GetUploadedPhotoNames(string orderID)
        {
            string html = GetUploadPhotoPage(orderID);

            Regex re = new Regex("<td colspan=\"5\" align=\"center\">([0-9A-Z_.]+)</td>", RegexOptions.Multiline);
            if (re.IsMatch(html))
            {
                MatchCollection mc = re.Matches(html);
                List<string> list = new List<string>();
                foreach (Match m in mc)
                {
                    list.Add(m.Groups[1].Value);
                }

                if (list.Count > 0)
                    return list.ToArray();
            }

            return null;
        }

        public string UploadPhoto(string orderID, string photoLocation)
        {
            return UploadPhoto(orderID, photoLocation, false);
        }

        public string UploadPhoto(string orderID, string photoLocation, bool overwriteExisting)
        {
            MemoryStream ms = new MemoryStream();
            byte[] data = null;
            StringBuilder sb = null;

            sb = new StringBuilder();
            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"actionType\"\r\n");
            sb.Append("\r\n");
            sb.Append("SUBMIT\r\n");

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"fileToDelete\"\r\n");
            sb.Append("\r\n");
            sb.Append("\r\n");

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"uploadFile\"; filename=\"" + Path.GetFileName(photoLocation) + "\"\r\n");
            sb.Append("Content-Type: image/pjpeg\r\n");
            sb.Append("\r\n");

            data = Encoding.UTF8.GetBytes(sb.ToString());
            ms.Write(data, 0, data.Length);

            data = GetPhoto(photoLocation);
            ms.Write(data, 0, data.Length);

            sb = new StringBuilder();
            sb.Append("\r\n");

            if (overwriteExisting)
            {
                sb.Append("--" + boundary + "\r\n");
                sb.Append("Content-Disposition: form-data; name=\"overwriteExisting\"\r\n");
                sb.Append("\r\n");
                sb.Append("on\r\n");
            }

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"x\"\r\n");
            sb.Append("\r\n");
            sb.Append("1\r\n");

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"y\"\r\n");
            sb.Append("\r\n");
            sb.Append("1\r\n");

            sb.Append("--" + boundary + "--\r\n");

            data = Encoding.UTF8.GetBytes(sb.ToString());
            ms.Write(data, 0, data.Length);

            byte[] html = bpoDirect.PostMultiPart(string.Format(uploadPhotoURL, orderID), boundary, ms.ToArray());
            return Encoding.UTF8.GetString(html);
        }

        public string DeletePhoto(string orderID, string photoName)
        {
            MemoryStream ms = new MemoryStream();
            byte[] data = null;
            StringBuilder sb = null;

            sb = new StringBuilder();
            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"actionType\"\r\n");
            sb.Append("\r\n");
            sb.Append("REMOVE\r\n");

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"fileToDelete\"\r\n");
            sb.Append("\r\n");
            sb.Append(photoName.ToUpper() + "\r\n");

            sb.Append("--" + boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"uploadFile\"; filename=\"\"\r\n");
            sb.Append("Content-Type: application/octet-stream\r\n");
            sb.Append("\r\n");
            sb.Append("\r\n");

            sb.Append("--" + boundary + "--\r\n");

            data = Encoding.UTF8.GetBytes(sb.ToString());
            ms.Write(data, 0, data.Length);

            byte[] html = bpoDirect.PostMultiPart(string.Format(uploadPhotoURL, orderID), boundary, ms.ToArray());
            return Encoding.UTF8.GetString(html);
        }

        #endregion

        #region Helpers

        private byte[] GetPhoto(string photoLocation)
        {
            byte[] data = null;
            using (FileStream fs = File.Open(photoLocation, FileMode.Open, FileAccess.Read))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Flush();
            }

            return data;
        }

        private string GetPage(string url)
        {
            byte[] html = bpoDirect.Get(url);
            return Encoding.UTF8.GetString(html);
        }

        #endregion
    }
}
