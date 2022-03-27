using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAMCO_MAPPING1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button
                    LinkButton4.Visible = false;
                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button
                    LinkButton5.Visible = false;
                    LinkButton.Visible = false;

                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button
                    LinkButton.Visible = true;
                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello" +" "+ Session["NAME"].ToString();
                    LinkButton5.Visible = true;
                    LinkButton4.Visible = true;


                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";






                }
            }
            catch (Exception ex)
            {

            }
        }
        void clear()
        {

            Session["username"] = "";
            Session["NAME"] = "";
            Session["ADDRESS_1"] = "";
            Session["CITY"] = "";
            Session["STATE"] = "";
            Session["PINCODE"] = "";
            Session["MOBILE"] = "";
            Session["EMAIL"] = "";
            Session["PAN"] = "";
            Session["GST"] = "";
            Session["BANK"] = "";
            Session["HINT_Q"] = "";
            Session["HINT_A"] = "";
            Session["Password"] = "";
            Session["role"] = "";

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            clear();
            Response.Redirect("Default.aspx");

           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("user profile.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stockinfo.aspx");  
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salesinfo.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm4.aspx");
        }
    }

}