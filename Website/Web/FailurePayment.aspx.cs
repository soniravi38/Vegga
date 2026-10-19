using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_FailurePayment : System.Web.UI.Page
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
        string TxnId = Request.Form["txnid"].ToString();
        string mode = Request.Form["mode"].ToString();
        string status = Request.Form["status"].ToString();
        string error = Request.Form["error"].ToString();
        string PG_Type = Request.Form["PG_Type"].ToString();
        string PayuMoneyID = Request.Form["mihpayid"].ToString();
        string bank_ref_num = Request.Form["bank_ref_num"].ToString();
        string message = Request.Form["error_Message"].ToString();
        string Result = "";
        string ErrorCode = "";
        lblTxnId.Text = TxnId;
        lblDate.Text = DateTime.Now.ToString();
        DataTable dt = cls.select_data_dt("Exec Proc_PayuMoney 'GetByTranId','0','" + TxnId + "','','','','','','','','','','','','','',''");
        string Amount = dt.Rows[0]["Amount"].ToString();
        string id = dt.Rows[0]["Id"].ToString();
        Int32 intresult = 0;
        intresult = cls.insert_data("Exec Proc_PayuMoney 'Update','" + id + "','','','','','','','','" + mode + "','" + status + "','" + error + "','" + PG_Type + "','" + PayuMoneyID + "','" + bank_ref_num + "','" + message + "','" + Result + "','" + ErrorCode + "'");
        if (intresult > 0)
        {
            string text = "your payment of Rs. " + Amount + " is Failed for Your TxnId " + TxnId + ". ";
            SendMessage.sms(text);
        }
        #endregion
    }
}