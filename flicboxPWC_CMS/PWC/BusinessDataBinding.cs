using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS.PWC
{
    public class BusinessDataBinding
    {
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        public string strDropDownInitialText = "--(Select)--";

        public SqlConnection con = new SqlConnection(conStr);
        public SqlCommand cmd = null;
        public SqlDataAdapter da = null;
        public SqlDataReader dr = null;

        public void BindGridView(GridView _gview, string _strQuery, System.Web.UI.Page _page)
        {
            try
            {
                da = new SqlDataAdapter(_strQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                _gview.DataSource = dt;
                _gview.DataBind();
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BusinessDataBinding.BindGridView()", _page);
                _page.Session.Abandon();
                _page.Response.Redirect("ErrorPage.aspx?errno=2");
            }
        }

        public void BindRepeater(Repeater _repeater, string _strQuery, System.Web.UI.Page _page)
        {
            try
            {
                da = new SqlDataAdapter(_strQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                _repeater.DataSource = dt;
                _repeater.DataBind();
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BusinessDataBinding.BindRepeater()", _page);
                _page.Session.Abandon();
                _page.Response.Redirect("ErrorPage.aspx?errno=2");
            }
        }

        public void BindDataList(DataList dlist, string _strQuery, System.Web.UI.Page _page)
        {
            try
            {
                da = new SqlDataAdapter(_strQuery, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dlist.DataSource = dt;
                dlist.DataBind();
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BusinessDataBinding.BindDataList()", _page);
                _page.Session.Abandon();
                _page.Response.Redirect("ErrorPage.aspx?errno=2");
            }
        }

        public void BindDropDownList(DropDownList _ddlList, string _strQuery, string _strInitialValueField, string _strInitialTextField, System.Web.UI.Page _page)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ValueField", typeof(string));
                dt.Columns.Add("TextField", typeof(string));

                DataRow drowInitial = dt.NewRow();
                drowInitial["ValueField"] = _strInitialValueField;
                drowInitial["TextField"] = _strInitialTextField;

                dt.Rows.Add(drowInitial);

                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                cmd = new SqlCommand(_strQuery, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DataRow drow = dt.NewRow();
                    drow["ValueField"] = dr.GetValue(0).ToString();
                    drow["TextField"] = dr.GetValue(1).ToString();
                    dt.Rows.Add(drow);
                }

                _ddlList.DataSource = dt;
                _ddlList.DataValueField = dt.Columns[0].Caption.ToString();
                _ddlList.DataTextField = dt.Columns[1].Caption.ToString();
                _ddlList.DataBind();
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BusinessDataBinding.BindDropDownList()", _page);
                _page.Session.Abandon();
                _page.Response.Redirect("ErrorPage.aspx?errno=2");
            }
            finally { con.Close(); }
        }

        public void BindDropDownList(DropDownList _ddlList, ArrayList _arrTextFields)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ValueField", typeof(string));
            dt.Columns.Add("TextField", typeof(string));

            DataRow drowInitial = dt.NewRow();
            drowInitial["ValueField"] = strDropDownInitialText;
            drowInitial["TextField"] = strDropDownInitialText;

            dt.Rows.Add(drowInitial);

            for (int i = 0; i < _arrTextFields.Count; i++)
            {
                DataRow drow = dt.NewRow();
                drow["TextField"] = _arrTextFields[i].ToString();
                drow["ValueField"] = i.ToString();
                dt.Rows.Add(drow);
            }

            _ddlList.DataSource = dt;
            _ddlList.DataValueField = dt.Columns[0].Caption.ToString();
            _ddlList.DataTextField = dt.Columns[1].Caption.ToString();
            _ddlList.DataBind();
        }

        public int ExecuteNonQuery(string _query, System.Web.UI.Page _page)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                cmd = new SqlCommand(_query, con);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace.ToString(), ex.TargetSite.ToString(), "BusinessDataBinding.ExecuteNonQuery()", _page);
                _page.Session.Abandon();
                _page.Response.Redirect("ErrorPage.aspx?errno=2");
                return 0;
            }
            finally { con.Close(); }
        }
    }
}