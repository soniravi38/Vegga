using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_ListRatingMaster : System.Web.UI.Page
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
            GridViewSortDirection = SortDirection.Descending;
            lblHeading.Text = "List Ratings";
            lblInsert1.Text = "Add Rating";
            lblInsert2.Text = "Add Rating";
        }
    }
    #endregion

    #region [All-Function]
    private void fillList()
    {
        cls_connection cls = new cls_connection();
        Guid ID = new Guid();
        dt = cls.select_data_dt("Proc_RatingMaster 'GetAll','" + ID + "',''");
        gvReport.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        gvReport.DataSource = dt;
        gvReport.DataBind();
        litrecordcount.Text = dt.Rows.Count.ToString();
        ViewState["dtExport"] = dt;
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
                dt = cls.select_data_dt("Proc_RatingMaster 'IsDelete','" + e.CommandArgument + "',''");
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
                dt1 = cls1.select_data_dt("Proc_RatingMaster 'IsActive','" + e.CommandArgument + "',''");
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

    
}