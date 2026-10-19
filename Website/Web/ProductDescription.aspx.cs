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

public partial class Web_ProductDescription : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    SendSMS SendMessage = new SendSMS();
    #endregion

    #region[PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["ProductID"].ToString() != null)
            {
                GetProductInfo(Guid.Parse(Request.QueryString["ProductID"].ToString()));
                GetProductAllPictures(Guid.Parse(Request.QueryString["ProductID"].ToString()));
                GetProductDescription(Guid.Parse(Request.QueryString["ProductID"].ToString()));
            }
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetProductInfo(Guid ProductID)
    {
        dt = cls.select_data_dt("Exec Proc_ProductMaster 'Get','" + ProductID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            lblProductName.Text = dt.Rows[0]["Name"].ToString();
            lblProductName1.Text = dt.Rows[0]["Name"].ToString();
            imgProductMain.ImageUrl= "../App_Content/Picture/Product/actual/"+ dt.Rows[0]["Picture"].ToString();
        }
    }

    private void GetProductAllPictures(Guid ProductID)
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ProductPictureMaster 'GetByProductID','" + ID + "','"+ ProductID + "',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repProductPictures.DataSource = dtNew.DefaultView;
            repProductPictures.DataBind();
        }
    }

    private void GetProductDescription(Guid ProductID)
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ProductDescriptionMaster 'GetByProductID','" + ID + "','" + ProductID + "','',''");
        if (dt.Rows.Count > 0)
        {
            lblProductPrice.Text= dt.Rows[0]["ShortDescription"].ToString();
            lblProductDescription.Text = dt.Rows[0]["FullDescription"].ToString();
        }
    }
    #endregion
}