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

public partial class Web_Products : System.Web.UI.Page
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
            FillProduct();
            GetHeaderImage();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["OurProducts"]);
        }
    }

    private void FillProduct()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ProductMaster 'GetAll1','" + ID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repProduct.DataSource = dtNew.DefaultView;
            repProduct.DataBind();
        }
    }
    #endregion

    #region[AllEvents]
    protected void repProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string ProductID = (e.Item.FindControl("lblProductID") as Label).Text.ToString();
        Response.Redirect("GetInformations.aspx?ProductID="+ProductID);
    }
    #endregion
}