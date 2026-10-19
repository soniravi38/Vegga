using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_ListProductPicture : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtExport = new DataTable();
    cls_connection cls = new cls_connection();
    clsImageResize objImageResize = new clsImageResize();
    #endregion

    #region [pageload]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillList();
            FillProduct();
            GridViewSortDirection = SortDirection.Descending;
            lblHeading.Text = "List Products Picture";
            lblInsert1.Text = "Add Product Picture";
            lblInsert2.Text = "Add Product Picture";
        }
    }
    #endregion

    #region [All-Function]
    private void fillList()
    {
        cls_connection cls = new cls_connection();
        Guid ID = new Guid();
        dt = cls.select_data_dt("Proc_ProductPictureMaster 'GetAll','" + ID + "','"+ ID + "',''");
        gvReport.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        gvReport.DataSource = dt;
        gvReport.DataBind();
        litrecordcount.Text = dt.Rows.Count.ToString();
        ViewState["dtExport"] = dt;
    }

    private void FillProduct()
    {
        DataTable dt = new DataTable();
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ProductMaster 'GetAllForDDL','" + ID + "','" + ID + "','',''");
        ddlSearchBy.DataSource = dt;
        ddlSearchBy.DataValueField = "id";
        ddlSearchBy.DataTextField = "name";
        ddlSearchBy.DataBind();
        ddlSearchBy.Items.Insert(0, new ListItem("Search By Product", "0"));
    }
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }
    #endregion

    #region [GridViewEvents]
    protected void gvReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region [IsDelete]
        DataTable dt = new DataTable();
        cls_connection cls = new cls_connection();
        if (e.CommandName == "IsDelete")
        {
            try
            {
                dt = cls.select_data_dt("Proc_ProductPictureMaster 'IsDelete','" + e.CommandArgument + "','"+ e.CommandArgument + "',''");
                fillList();

            }
            catch
            {
                Function.MessageBox("Sorry. Something Went Wrong !");
            }
        }
        #endregion

        #region [IsActive]
        if (e.CommandName == "IsActive")
        {
            DataTable dt1 = new DataTable();
            cls_connection cls1 = new cls_connection();
            try
            {
                dt1 = cls1.select_data_dt("Proc_ProductPictureMaster 'IsActive','" + e.CommandArgument + "','"+ e.CommandArgument + "',''");
                fillList();
            }
            catch (Exception ex)
            {
                Function.MessageBox(ex.Message);
            }
        }
        #endregion
    }
    protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReport.PageIndex = e.NewPageIndex;
        fillList();
    }
    protected void gvReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)ViewState["dtExport"];
            DataView dv = new DataView(dt);
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                dv.Sort = e.SortExpression + " DESC";
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                dv.Sort = e.SortExpression + " ASC";
            }
            gvReport.DataSource = dv;
            gvReport.DataBind();
        }
        catch (Exception ex)
        { }
    }
    #endregion

    #region [ddlPaging]
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillList();
    }
    #endregion

    #region[AllEvents]
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchBy.SelectedIndex != 0)
        {
            Guid ProductID = Guid.Parse(ddlSearchBy.SelectedValue);
            Guid ID = new Guid();
            dt = cls.select_data_dt("Proc_ProductPictureMaster 'GetByProductIDForDDL','" + ID + "','" + ProductID + "',''");
            gvReport.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            gvReport.DataSource = dt;
            gvReport.DataBind();
            litrecordcount.Text = dt.Rows.Count.ToString();
            ViewState["dtExport"] = dt;
        }
        else
        {
            fillList();
        }
    }
    #endregion
}