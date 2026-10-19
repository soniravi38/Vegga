using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Developed by: Harish Kr Patidar
/// Created on : 05-01-2016
/// Used To send Email
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool SendAddCashViaPG(string ToEmail, string Amount)
    {
        try
        {
            string[] valueArray = new string[2];
            valueArray[0] = Amount;
            FlexiMail objSendMail = new FlexiMail();
            objSendMail.To = ToEmail;
            objSendMail.CC = "";
            objSendMail.BCC = "";
            objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);
            objSendMail.FromName = "shintars.net";
            objSendMail.MailBodyManualSupply = false;
            objSendMail.EmailTemplateFileName = "../../../EmailTemplates/FundAddViaPG.htm";
            objSendMail.Subject = "Fund Added-Via Payment Gateway";
            objSendMail.ValueArray = valueArray;
            objSendMail.Send();
            return true;
        }
        catch 
        {
            return false;
        }
    }
    public static bool SendAddCashViaPGB2C(string ToEmail, string Amount)
    {
        try
        {
            string[] valueArray = new string[2];
            valueArray[0] = Amount;
            FlexiMail objSendMail = new FlexiMail();
            objSendMail.To = ToEmail;
            objSendMail.CC = "";
            objSendMail.BCC = "";
            objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);
            objSendMail.FromName = "shintars.net";
            objSendMail.MailBodyManualSupply = false;
            objSendMail.EmailTemplateFileName = "FundAddViaPG.htm";
            objSendMail.Subject = "Fund Added-Via Payment Gateway";
            objSendMail.ValueArray = valueArray;
            objSendMail.Send();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool SendForgotPassword(string ToEmail, string Password)
    {
        try
        {
            string[] valueArray = new string[2];
            valueArray[0] = ToEmail;
            valueArray[1] = Password;
            FlexiMail objSendMail = new FlexiMail();
            objSendMail.To = ToEmail;
            objSendMail.CC = "";
            objSendMail.BCC = "";
            objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);
            objSendMail.FromName = "shintars.net";
            objSendMail.MailBodyManualSupply = false;
            objSendMail.EmailTemplateFileName = "../../../EmailTemplates/ForgetPassword.htm";
            objSendMail.Subject = "Password Recovery";
            objSendMail.ValueArray = valueArray;
            objSendMail.Send();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool SendRechargeReceipt(string ToEmail, string MailBody)
    {
        try
        {
            FlexiMail objSendMail = new FlexiMail();
            objSendMail.To = ToEmail;
            objSendMail.CC = "";
            objSendMail.BCC = Convert.ToString(ConfigurationManager.AppSettings["mailBCC"]);
            objSendMail.From = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);
            objSendMail.FromName = Convert.ToString(ConfigurationManager.AppSettings["mailFrom"]);
            objSendMail.MailBodyManualSupply = true;
            objSendMail.Subject = "Recharge Receipt";
            objSendMail.MailBody = MailBody;
            objSendMail.Send();
            return true;
        }
        catch
        {
            return false;
        }
    }
}