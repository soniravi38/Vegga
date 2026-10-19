using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;
using System.Data.OleDb;
using System.Text;

public partial class Admin_AddCertificatePhoto : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    cls_connection cls = new cls_connection();
    clsImageResize objImageResize = new clsImageResize();
    #endregion

    #region [pageload]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                lblHeading.Text = "Update Certificate Photo";
                btnSubmit.Text = "Update";
            }
            else
            {
                lblHeading.Text = "Adding Testing Certificate Photos";
                btnSubmit.Text = "Bulk Upload";
            }
        }
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fuPicture.HasFile)
        {
            HttpFileCollection _HttpFileCollection = Request.Files;

            for (int i = 0; i < _HttpFileCollection.Count; i++)
            {
                HttpPostedFile _HttpPostedFile = _HttpFileCollection[i];
                if (_HttpPostedFile.ContentLength > 0)
                    _HttpPostedFile.SaveAs(Server.MapPath("~/App_Content/Picture/Certificate/actual/" + Path.GetFileName(_HttpPostedFile.FileName)));
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('All Photos are Inserted successfully.');window.location='ListTestingCertificates.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Oops! please Select Photos')</script>");
        }
    }
    #endregion
}