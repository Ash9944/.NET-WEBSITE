using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


namespace RAMCO_MAPPING1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ASH;Initial Catalog=Registration_FormDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM User_registration where SUB_DEALER_CODE = '" + TextBox1.Text + "' AND Password = '" + TextBox2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Session["username"] = dr.GetValue(0).ToString();
                    Session["NAME"] = dr.GetValue(1).ToString();
                    Session["ADDRESS_1"] = dr.GetValue(2).ToString();
                    Session["CITY"] = dr.GetValue(3).ToString();
                    Session["STATE"] = dr.GetValue(4).ToString();
                    Session["PINCODE"] = dr.GetValue(5).ToString();
                    Session["MOBILE"] = dr.GetValue(6).ToString();
                    Session["EMAIL"] = dr.GetValue(7).ToString();
                    Session["PAN"] = dr.GetValue(8).ToString();
                    Session["GST"] = dr.GetValue(9).ToString();
                    Session["BANK"] = dr.GetValue(10).ToString();
                    Session["HINT_Q"] = dr.GetValue(11).ToString();
                    Session["HINT_A"] = dr.GetValue(12).ToString();
                    Session["Password"] = dr.GetValue(13).ToString();




                }

                Session["role"] = "user";
                Response.Redirect("WebForm4.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials')</script>");


            }

            
        }
    } }