using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RAMCO_MAPPING1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)


        {
            try
            {


                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {


                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }

            }
            catch (Exception ex)
            {

            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    updateUserPersonalDetails();

                }
            }
            catch(Exception ex)
            {

            }

        }
        void updateUserPersonalDetails()
        {
            string password = "";
            if (Txtnewpass.Text.Trim() == "")
            {
                password = Txtoldpass.Text.Trim();
            }
            else
            {
                password = Txtnewpass.Text.Trim();
            }

            SqlConnection con = new SqlConnection("Data Source=ASH;Initial Catalog=Registration_FormDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }



            SqlCommand cmd = new SqlCommand("UPDATE User_registration SET [NAME] = '"+Txtname.Text+"', ADDRESS_1 = '"+Txtaddress.Text+"',[CITY] = '"+ Txtcity.Text + "',[STATE] = '"+ DropDownList1.SelectedValue + "',[PINCODE] = '"+ TxtPIN.Text + "',[MOBILE] = '" + Txtnumber.Text + "',[EMAIL] = '"+ Txtmail.Text + "',[PAN_NUMBER] = '" + TxtPAN.Text + "',[GST_NUMBER] = '" + TextGST.Text + "',[BANK_NAME] = '" +TxtBANK.Text+"',[HINT_QUESTION] = '" + Hint_q.Text + "',[HINT_ANSWER] = '" + Hint_a.Text + "',[Password] = '"+password+"' where SUB_DEALER_CODE = '"+Session["username"]+"'", con);




            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {

                Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                getUserPersonalDetails();

            }
            else
            {
                Response.Write("<script>alert('Invaid entry');</script>");
            }

        }
        void getUserPersonalDetails()
        {

            SqlConnection con = new SqlConnection("Data Source=ASH;Initial Catalog=Registration_FormDB;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from user_registration where SUB_DEALER_CODE='" + Session["username"].ToString() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Txtname.Text = dt.Rows[0]["NAME"].ToString();
            Txtaddress.Text = dt.Rows[0]["ADDRESS_1"].ToString();
            Txtcity.Text = dt.Rows[0]["CITY"].ToString();
            Txtmail.Text = dt.Rows[0]["EMAIL"].ToString();
            DropDownList1.SelectedValue = dt.Rows[0]["STATE"].ToString().Trim();
            TextGST.Text = dt.Rows[0]["GST_NUMBER"].ToString();
            TxtPIN.Text = dt.Rows[0]["PINCODE"].ToString();
            TxtPAN.Text = dt.Rows[0]["PAN_NUMBER"].ToString();
            Txtcode.Text = dt.Rows[0]["SUB_DEALER_CODE"].ToString();
            Txtoldpass.Text = dt.Rows[0]["Password"].ToString();
            TxtBANK.Text = dt.Rows[0]["BANK_NAME"].ToString();
            Hint_q.Text = dt.Rows[0]["HINT_QUESTION"].ToString();
            Hint_a.Text = dt.Rows[0]["HINT_ANSWER"].ToString();
            Txtnumber.Text = dt.Rows[0]["MOBILE"].ToString();






        }

    } 
}
