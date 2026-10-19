using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Web_Default2 : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCompanyInfo();
            GetAboutText();
            FillMainSlider();
            FillMainImages();
            FillProduct();
            FillRating();
            FillReview();
            FillBlogs();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetCompanyInfo()
    {
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            lblCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
        }
    }
    private void GetAboutText()
    {
        dt = cls.select_data_dt("Exec Proc_AboutUs 'GetAll','',''");
        if (dt.Rows.Count > 0)
        {
            lblAboutUsText.Text = dt.Rows[0]["AboutUsText"].ToString();
            lblWhyUsText.Text = dt.Rows[0]["WhyUsText"].ToString();
        }
    }
    private void FillMainSlider()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_MainSlider 'GetAll1','"+ ID + "',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repMainSlider.DataSource = dtNew.DefaultView;
            repMainSlider.DataBind();
        }
    }

    private void FillMainImages()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_MainImages 'GetAll1','" + ID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repMainImages.DataSource = dtNew.DefaultView;
            repMainImages.DataBind();
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

    private void FillRating()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_RatingMaster 'GetAll1','" + ID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repRating.DataSource = dtNew.DefaultView;
            repRating.DataBind();
        }
    }

    private void FillReview()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ReviewMaster 'GetAll1','" + ID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repReview.DataSource = dtNew.DefaultView;
            repReview.DataBind();
        }
    }

    private void FillBlogs()
    {
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_BlogMaster 'GetAll1','" + ID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            DataView dv1 = dt.DefaultView;
            DataTable dtNew = dv1.ToTable();
            repBlogs.DataSource = dtNew.DefaultView;
            repBlogs.DataBind();
        }
    }
    #endregion

    #region[AllEvents]
    protected void repProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string ProductID = (e.Item.FindControl("lblProductID") as Label).Text.ToString();
        Response.Redirect("GetInformations.aspx?ProductID=" + ProductID);
    }
    #endregion
}