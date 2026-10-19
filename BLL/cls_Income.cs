using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class cls_Income
    {
        public DataTable MLMRO_Generate_Q_LEVEL_Income(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_Generate_Q_LEVEL_Income(mm,yy);
            } return dt;
        }

        public DataTable MLMRO_Show_Q_LEVEL_Income(int mm, int yy)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_Show_Q_LEVEL_Income(mm, yy);
            } return dt;
        }
        public DataTable MLMRO_Income_LEVEL_income(int msrno)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_Income_LEVEL_income(msrno);
            } return dt;
        }
        public DataTable MLMRO_List_LEVEL_income(int msrno)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_List_LEVEL_income(msrno);
            } return dt;
        }

        public DataTable MLMRO_List_Q_LEVEL_Member(int msrno,int levelid)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_List_Q_LEVEL_Member(msrno,levelid);
            } return dt;
        }

        public DataTable MLMRO_Manage_Q_LEVEL_Setting(string Action, int ID, string str)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_Manage_Q_LEVEL_Setting(Action, ID, str);
            } return dt;
        }


        public DataTable MLMRO_GetDate_Generate()
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLMRO_GetDate_Generate();
            } return dt;
        }
        public DataTable MLM_RO_Get_AutoPool_line(int line)
        {
            DataTable dt = new DataTable();
            using (DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter obj = new DAL.DataSetIncomeTableAdapters.tblMLM_MemberMasterTableAdapter())
            {
                dt = obj.MLM_RO_Get_AutoPool_line(line);
            } return dt;
        }
       
    }
}

