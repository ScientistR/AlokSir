using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;

namespace Class26219
{
    public partial class AddCompany : System.Web.UI.Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void Insert(int D,string A, string B, int C)
        {
            if (D > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_emp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", D);
                cmd.Parameters.AddWithValue("@name", A);
                cmd.Parameters.AddWithValue("@address", B);
                cmd.Parameters.AddWithValue("@age", C);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_emp_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", A);
                cmd.Parameters.AddWithValue("@address", B);
                cmd.Parameters.AddWithValue("@age", C);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        [WebMethod]
        public static void Delete(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_emp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", A);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public static string Get()
        {
            string p = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_emp_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                p = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return p;
        }

        [WebMethod]
        public static string Edit(int A)
        {
            string p = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_emp_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", A);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                p = JsonConvert.SerializeObject(ds.Tables[0]);
            }
            return p;
        }
    }
}