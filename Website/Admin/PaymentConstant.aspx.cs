using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_PaymentConstant : System.Web.UI.Page
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
            lblHeading.Text = "Payment Constant";
            btnSubmit.Text = "Update";
            btnDelete.Visible = false;
            FillData();
        }
    }
    #endregion

    #region [all-fuctions]
    private void FillData()
    {
        dt = cls.select_data_dt("Exec Proc_PaymentConstant 'GET','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            txtMerchantKey.Text = Convert.ToString(dt.Rows[0]["MerchantKey"]);
            txtSaltKey.Text = Convert.ToString(dt.Rows[0]["SaltKey"]);
            txtProductInfo.Text = Convert.ToString(dt.Rows[0]["ProductInfo"]);
            txtudf5.Text = Convert.ToString(dt.Rows[0]["udf5"]);
            txtsurl.Text = Convert.ToString(dt.Rows[0]["surl"]);
            txtfurl.Text = Convert.ToString(dt.Rows[0]["furl"]);
            txtPaymentURL.Text = Convert.ToString(dt.Rows[0]["PaymentURL"]);
        }
    }
    private void clear()
    {
        txtMerchantKey.Text = "";
        txtSaltKey.Text = "";
        txtProductInfo.Text = "";
        txtudf5.Text = "";
        txtsurl.Text = "";
        txtfurl.Text = "";
        txtPaymentURL.Text = "";
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region [update]
        Int32 intresult = 0;
        intresult = cls.insert_data("Exec Proc_PaymentConstant 'Update','" + txtMerchantKey.Text+"','"+txtSaltKey.Text+"','"+ txtProductInfo.Text + "','"+ txtudf5.Text + "','"+txtsurl.Text+"','"+txtfurl.Text+"','"+txtPaymentURL.Text+ "'");
        if (intresult > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='Dashboard.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Oops! something went wrong')</script>");
            clear();
        }
        #endregion
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    #endregion
}