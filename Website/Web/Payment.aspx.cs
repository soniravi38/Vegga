using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Security.Cryptography;

public partial class Web_Payment : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    SendSMS SendMessage = new SendSMS();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCompanyInfo();
            GetHeaderImage();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetCompanyInfo()
    {
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            //CompanyMap.Attributes.Add("src", dt.Rows[0]["GoogleMapApi"].ToString());
            imgCompanyLogo.ImageUrl = "../App_Content/Picture/CompanyLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyLogo"]);
            lblCompanyAddress.Text = dt.Rows[0]["Address"].ToString();
            lblFooterMobile.Text = dt.Rows[0]["Mobile1"].ToString() + ", " + dt.Rows[0]["Mobile2"].ToString();
            lblFooterPhone.Text = dt.Rows[0]["Phone1"].ToString() + ", " + dt.Rows[0]["Phone2"].ToString();
            lblFooterEmail.Text = dt.Rows[0]["email1"].ToString() + ", " + dt.Rows[0]["email2"].ToString();
        }
    }

    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["Payment"]);
        }
    }
    #endregion

    #region[AllEvents]
    protected void btnQuerySubmit_Click(object sender, EventArgs e)
    {
        string outputHTML = "";
        Guid PaymentInfoId = Guid.Empty;
        try
        {
            dt = cls.select_data_dt("Exec Proc_PaymentConstant 'GET','','','','','','',''");
            string MerchantKey = Convert.ToString(dt.Rows[0]["MerchantKey"]);
            string SaltKey = Convert.ToString(dt.Rows[0]["SaltKey"]);
            string Amount = txtAmount.Text;
            Random generator = new Random();
            String TxnId = "VEGGA"+generator.Next(0, 999999).ToString("D6");
            string ProductInfo = Convert.ToString(dt.Rows[0]["ProductInfo"]);
            string FirstName = txtFirstName.Text;
            string Email = txtEmail.Text;
            string Mobile = txtMobile.Text;
            string Remark = txtRemark.Text;
            string udf5 = Convert.ToString(dt.Rows[0]["udf5"]);
            string surl = Convert.ToString(dt.Rows[0]["surl"]);
            string furl = Convert.ToString(dt.Rows[0]["furl"]);
            string text = MerchantKey + "|" + TxnId + "|" + Amount + "|" + ProductInfo + "|" + FirstName + "|" + Email + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + SaltKey;
            byte[] message = Encoding.UTF8.GetBytes(text);
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("hash", hex.ToString());
            parameter.Add("txnid", TxnId);
            parameter.Add("key", MerchantKey);
            parameter.Add("Amount", Amount);
            parameter.Add("firstname", FirstName);
            parameter.Add("email", Email);
            parameter.Add("phone", Mobile);
            parameter.Add("productinfo", ProductInfo);
            parameter.Add("udf1", "1");
            parameter.Add("udf2", "1");
            parameter.Add("udf3", "1");
            parameter.Add("udf4", "1");
            parameter.Add("udf5", "1");
            parameter.Add("surl", surl);
            parameter.Add("furl", furl);
            parameter.Add("service_provider", "");
            Int32 intresult = 0;
            intresult = cls.insert_data("Exec Proc_PayuMoney 'Insert','0','" + TxnId + "','" + FirstName + "','" + ProductInfo + "','" + Email + "','" + Mobile + "','"+Amount+"','"+ Remark + "','','Pending','','','','','','',''");
            if (intresult > 0)
            {
                outputHTML = CreateFormPayu(Convert.ToString(dt.Rows[0]["PaymentURL"]), parameter);
                Page.Controls.Add(new LiteralControl(outputHTML));
            }
        }
        catch ( Exception ex)
        {

        }
    }
    #endregion

    #region[AllFunction]
    public string CreateFormPayu (string PayuURL, Dictionary<string,string> parameters)
    {
        string FormName = "form1";
        string Method = "post";
        string outputHTML = "";
        outputHTML = "<html>";
        outputHTML += "<head>";
        outputHTML += "<title>Merchant Check Out Page </title>";
        outputHTML += "</head>";
        outputHTML += "<body onload='document." + FormName + ".submit()'>";
        outputHTML += "<center><h1>Please do not refresh this page....</h1></center>";
        outputHTML += "<form method='" + Method + "' action = '" + PayuURL + "' name='" + FormName + "'>";
        outputHTML += "<table border='1'>";
        outputHTML += "<tbody>";
        foreach (string key in parameters.Keys)
        {
            outputHTML += "<input type='hidden' name='" + key + "'value='" + parameters[key] + "'>";
        }
        outputHTML += "</form>";
        outputHTML += "</body>";
        outputHTML += "</html>";
        outputHTML += "<html>";
        return outputHTML;
    }
    #endregion

}