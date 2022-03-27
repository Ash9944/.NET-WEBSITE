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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GVbind();
            }

        }
        void clear()
        {
            TextBox1.Text = "";
            Txtname.Text = "";
            TextBox2.Text = "";

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SUBDEALER_DAILY_SALES_INFORMATION
                ([CODE]    
	            ,[ITEM_NAME]   
                ,[QUANTITY_OF_SALES_(MT)] 
                ,[DATE]
                 )
                VALUES
                 ('" + Session["username"] + "', '" + TextBox1.Text + "', '" + Txtname.Text + "', '" + TextBox2.Text + "')", con);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {

                GVbind();

            }
            clear();


        }
        protected void btnreset_Click(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            Txtname.Text = "";
            TextBox2.Text = "";
        }

        protected void GVbind()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(@"SELECT ID,ITEM_NAME,[QUANTITY_OF_SALES_(MT)],DATE FROM SUBDEALER_DAILY_SALES_INFORMATION  where CODE = '" + Session["username"] + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();

            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM SUBDEALER_DAILY_SALES_INFORMATION where ID = '" + id + "'", con);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                GridView1.EditIndex = -1;
                GVbind();

            }


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GVbind();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string itemname = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string quantity = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string date = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("UPDATE SUBDEALER_DAILY_SALES_INFORMATION SET ITEM_NAME='" + itemname + "',[QUANTITY_OF_SALES_(MT)]='" + quantity + "',DATE='" + date + "' where ID = '" + id + "'", con);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                GridView1.EditIndex = -1;
                GVbind();

            }

        }

        protected void btnSubmit_Click2(object sender, EventArgs e)
        {
            Response.Redirect("Referalinfo.aspx");
        }
    }
}