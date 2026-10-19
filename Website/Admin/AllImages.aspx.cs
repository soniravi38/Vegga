using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AllImages : System.Web.UI.Page
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
            lblHeading.Text = "Update All Images";
            btnSubmit.Text = "Update";
            btnDelete.Visible = false;
        }
    }
    #endregion

    #region [All-Events]
    private string uploadContactUs()
    {
        if (fuContactUs.HasFile == true)
        {
            if (fuContactUs.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuContactUs.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuContactUs.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuContactUs.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string uploadAboutUs()
    {
        if (fuAboutUs.HasFile == true)
        {
            if (fuAboutUs.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuAboutUs.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuAboutUs.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuAboutUs.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string uploadProducts()
    {
        if (fuProducts.HasFile == true)
        {
            if (fuProducts.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuProducts.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuProducts.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuProducts.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string uploadClientInfo()
    {
        if (fuClientInfo.HasFile == true)
        {
            if (fuClientInfo.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuClientInfo.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuClientInfo.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuClientInfo.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string UploadCallUs()
    {
        if (fuCallUs.HasFile == true)
        {
            if (fuCallUs.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuCallUs.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuCallUs.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuCallUs.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string UploadCertificates()
    {
        if (fuCertificates.HasFile == true)
        {
            if (fuCertificates.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuCertificates.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuCertificates.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuCertificates.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private string UploadPayment()
    {
        if (fuPayment.HasFile == true)
        {
            if (fuPayment.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/AllImages/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/AllImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/AllImages/small/");
                string Extension = System.IO.Path.GetExtension(fuPayment.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuPayment.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuPayment.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region [update]
        Int32 intresult = 0;
        string ContactUs = uploadContactUs();
        string AboutUs = uploadAboutUs();
        string Products = uploadProducts();
        string ClientInfo = uploadClientInfo();
        string CallUs = UploadCallUs();
        string Certificates = UploadCertificates();
        string Payment = UploadPayment();
        intresult = cls.insert_data("Exec Proc_AllImages 'Update','" + ContactUs + "','"+ AboutUs + "','"+ Products + "','"+ ClientInfo + "','"+ CallUs + "','"+ Certificates + "','"+ Payment + "'");
        if (intresult > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='Dashboard.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Oops! something went wrong')</script>");
        }
        #endregion
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       
    }
    #endregion
}