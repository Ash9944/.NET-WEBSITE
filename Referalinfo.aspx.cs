using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAMCO_MAPPING1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void clear()
        {
            Txtname.Text = "";
            Txttype.Text = "";
            Txtnumber.Text = "";
            Txtaddress.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand(@"INSERT INTO REFERAL_INFORMATION
                ([CODE]
                  ,[INFLUENCER_NAME]
                  ,[INFLUENCER_TYPE]
                  ,[MOBILE_NUMBER]
                  ,[ADDRESS]

                 )
                VALUES
                 ('" +Session["username"]+ "','" + Txtname.Text + "','" + Txttype.Text + "','" + Txtnumber.Text + "','" + Txtaddress.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Your referal was noted');</script>");
            clear();
        }
    }
}