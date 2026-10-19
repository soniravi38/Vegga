using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Software_Dashboard : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetDashBoardInfo();
        }
    }
    #endregion

    #region [AllFunctions]
    private void GetDashBoardInfo()
    {
        ds = cls.select_data_ds("Exec Proc_GetDashboardInfo 'GetAll'");
        if (ds.Tables.Count > 0)
        {
            lblTotalQueries.Text = ds.Tables[0].Rows[0]["TotalQueries"].ToString();
            lblVerifiedQueries.Text = ds.Tables[1].Rows[0]["VerifiedQueries"].ToString();
            lblUnverifiedQueries.Text = ds.Tables[2].Rows[0]["UnverifiedQueries"].ToString();
            lblCurrentLoginIP.Text= Convert.ToString(Request.UserHostAddress);
            lblSMS.Text = ds.Tables[3].Rows[0]["sms"].ToString();
            lblTotalCustomers.Text = ds.Tables[4].Rows[0]["TotalCustomers"].ToString();
            lblVerifiedCustomers.Text = ds.Tables[5].Rows[0]["VerifiedCustomers"].ToString();
            lblUnVerifiedCustomers.Text = ds.Tables[6].Rows[0]["UnverifiedCustomers"].ToString();
        }
    }
    #endregion
}