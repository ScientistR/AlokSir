using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Test_31jan
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
                BindGrid();
            }
        }
        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_country_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcountry.DataValueField = "cid";
                ddlcountry.DataTextField = "cname";
                ddlcountry.DataSource = ds;
                ddlcountry.DataBind();
                ddlcountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
            }
            else
            {
                ddlcountry.DataSource = null;
                ddlcountry.DataBind();
            }
        }

        public void BindState(string A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_state_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid",A);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlstate.DataValueField = "sid";
                ddlstate.DataTextField = "sname";
                ddlstate.DataSource = ds;
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
            else
            {
                ddlcountry.DataSource = null;
                ddlcountry.DataBind();
            }
        }

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_emp_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = ds;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_emp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@ctr", ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_emp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", ViewState["pp"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@ctr", ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_emp_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid",e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                    txtage.Text = ds.Tables[0].Rows[0]["age"].ToString();
                    ddlcountry.SelectedValue = ds.Tables[0].Rows[0]["ctr"].ToString();
                    btnsave.Text = "Update";
                    ViewState["pp"] = e.CommandArgument;
                }
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlstate.Enabled = true;
            BindState(ddlcountry.SelectedValue);
        }
    }
}