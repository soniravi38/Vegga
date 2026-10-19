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

public partial class Admin_AddMultipleTestingCertificate : System.Web.UI.Page
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
                lblHeading.Text = "Update Main Images";
                btnSubmit.Text = "Update";
            }
            else
            {
                lblHeading.Text = "Adding Bulk Testing Certificate";
                btnSubmit.Text = "Export";
            }
        }
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fuCSV.HasFile)
        {
            Random random = new Random();
            int RndNumber = random.Next(100000, 1000000);
            string fileName = Path.GetFileName(fuCSV.PostedFile.FileName);
            string fileExtension = Path.GetExtension(fuCSV.PostedFile.FileName);
            if (fileExtension == ".csv")
            {
                string fileLocation = Server.MapPath("~/App_Content/Certificate/" + RndNumber.ToString() + ".csv");
                fuCSV.SaveAs(fileLocation);
                string sbXML = CSVtoXML(fileLocation);
                dt = cls.select_data_dt("Exec Proc_MultipleCertificateMaster '" + sbXML + "'");
                if (dt.Rows[0]["Message"].ToString() == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('csv Data Inserted successfully.');window.location='ListTestingCertificates.aspx';", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('csv Data Inserted successfully and these Certificates are already exists - "+ dt.Rows[0]["Message"].ToString() + "');window.location='ListTestingCertificates.aspx';", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Only CSV file is allowed');window.location='AddMultipleTestingCertificate.aspx';", true);
            }
        }
        else
        {
            Response.Write("<script>alert('Oops! please Select CSV File')</script>");
        }
    }

    public string CSVtoXML(string FilePath)
    {
        StringBuilder sbXML = new StringBuilder();
        DataTable dt = new DataTable();
        DataSet DS = new DataSet();
        object objreturn = "";
        try
        {
            if (FilePath != "")
            {
                sbXML.AppendLine();
                string csvData = File.ReadAllText(FilePath);
                dt.Columns.AddRange(new DataColumn[36]
                {
                        new DataColumn("1", typeof(string)),
                        new DataColumn("2", typeof(string)),
                        new DataColumn("3", typeof(string)),
                        new DataColumn("4", typeof(string)),
                        new DataColumn("5", typeof(string)),
                        new DataColumn("6", typeof(string)),
                        new DataColumn("7", typeof(string)),
                        new DataColumn("8", typeof(string)),
                        new DataColumn("9", typeof(string)),
                        new DataColumn("10", typeof(string)),
                        new DataColumn("11", typeof(string)),
                        new DataColumn("12", typeof(string)),
                        new DataColumn("13", typeof(string)),
                        new DataColumn("14", typeof(string)),
                        new DataColumn("15", typeof(string)),
                        new DataColumn("16", typeof(string)),
                        new DataColumn("17", typeof(string)),
                        new DataColumn("18", typeof(string)),
                        new DataColumn("19", typeof(string)),
                        new DataColumn("20", typeof(string)),
                        new DataColumn("21", typeof(string)),
                        new DataColumn("22", typeof(string)),
                        new DataColumn("23", typeof(string)),
                        new DataColumn("24", typeof(string)),
                        new DataColumn("25", typeof(string)),
                        new DataColumn("26", typeof(string)),
                        new DataColumn("27", typeof(string)),
                        new DataColumn("28", typeof(string)),
                        new DataColumn("29", typeof(string)),
                        new DataColumn("30", typeof(string)),
                        new DataColumn("31", typeof(string)),
                        new DataColumn("32", typeof(string)),
                        new DataColumn("33", typeof(string)),
                        new DataColumn("34", typeof(string)),
                        new DataColumn("35", typeof(string)),
                        new DataColumn("36", typeof(string)),
                });
                int Count = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int j = 0;
                        int a = 0;
                        if (Count > 0)
                        {
                            a = 0;
                        }
                        else
                        {
                            a = 1;
                        }
                        foreach (string cell in row.Split(','))
                        {
                            if (cell.Trim() == "-")
                            {
                                dt.Rows[dt.Rows.Count - 1][j] = "0";
                            }
                            else if (cell.Trim() != string.Empty)
                            {
                                dt.Rows[dt.Rows.Count - 1][j] = cell;
                            }
                            j++;
                        }
                        if (a == 0)
                        {
                            sbXML.AppendLine("<nodes>");
                            sbXML.AppendLine("  <node>");
                            sbXML.AppendLine("<CertificateNo>" + dt.Rows[Count]["1"].ToString() + "</CertificateNo>");
                            sbXML.AppendLine("<Weight>" + dt.Rows[Count]["17"].ToString() + "</Weight>");
                            sbXML.AppendLine("<Unit>" + dt.Rows[Count]["3"].ToString() + "</Unit>");
                            sbXML.AppendLine("<ShapeCut>" + dt.Rows[Count]["4"].ToString() + "</ShapeCut>");
                            sbXML.AppendLine("<Dimension>" + dt.Rows[Count]["5"].ToString().Replace(",", ".") + "</Dimension>");
                            sbXML.AppendLine("<Color>" + dt.Rows[Count]["6"].ToString().Replace("&", "AND") + "</Color>");
                            sbXML.AppendLine("<RI> N/A </RI>");
                            sbXML.AppendLine("<StoneName>" + (dt.Rows[Count]["13"].ToString().Replace("'", "")).ToString().Replace("&", "AND") + "</StoneName>");
                            sbXML.AppendLine("<Comment>" + (dt.Rows[Count]["33"].ToString().Replace("'", "")).ToString().Replace("&","AND") + "</Comment>");
                            sbXML.AppendLine("<Variety>" + dt.Rows[Count]["11"].ToString() + "</Variety>");
                            sbXML.AppendLine("<Origin>" + dt.Rows[Count]["14"].ToString() + "</Origin>");
                            sbXML.AppendLine("  </node>");
                            sbXML.AppendLine("</nodes>");
                        }
                    }
                    Count++;
                }
            }
            return sbXML.ToString();
        }
        catch (Exception ex)
        {
            objreturn = ex.Message.ToString();
            throw;
        }
        finally
        {
            //SqlCrsv2process.Close();
        }
        return sbXML.ToString();
    }

    #endregion
}