using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace RAMCO_MAPPING1
{
    public partial class _Default : Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void clear()
        {
            Txtname.Text = "";
            Txtaddress.Text = "";
            Txtcity.Text = "";
            DropDownList1.SelectedItem.Value = "";
            TxtPIN.Text = "";
            Txtnumber.Text = "";
            Txtmail.Text = "";
            TxtPAN.Text = "";
            TextGST.Text = "";
            TxtBANK.Text = "";
            Hint_q.Text = "";
            Hint_a.Text = "";



        }
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this NAME and PAN, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }

        }
        bool checkMemberExists()
        {


            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM User_registration where NAME = '" + Txtname.Text + "' OR PAN_NUMBER = '" + TxtPAN.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");

            string pwd = CreateRandomPassword(8);
            Random random = new Random();
            int number = random.Next(100000, 999999);
            string code = number.ToString();
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand(@"INSERT INTO User_registration
                ([SUB_DEALER_CODE]
                  ,[NAME]
                  ,[ADDRESS_1]
                  ,[CITY]
                  ,[STATE]
                  ,[PINCODE]
                  ,[MOBILE]
                  ,[EMAIL]
                  ,[PAN_NUMBER]
                  ,[GST_NUMBER]
                  ,[BANK_NAME]
                  ,[HINT_QUESTION]
                  ,[HINT_ANSWER]
                  ,[Password]

                 )
                VALUES
                 ('" + code + "','" + Txtname.Text + "','" + Txtaddress.Text + "','" + Txtcity.Text + "','" + DropDownList1.SelectedItem.Value + "','" + TxtPIN.Text + "','" + Txtnumber.Text + "','" + Txtmail.Text + "','" + TxtPAN.Text + "','" + TextGST.Text + "','" + TxtBANK.Text + "','" + Hint_q.Text + "','" + Hint_a.Text + "','" + pwd + "')", con);
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + str));
                string Image = "~/Upload/" + str.ToString();

                
                SqlConnection Con = new SqlConnection(strcon);
                SqlCommand Cmd = new SqlCommand("insert into User_regstration (@Image)", con);

                Cmd.Parameters.AddWithValue("Image", Image);


            }
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("aswajith.1702063@srec.ac.in");
            msg.To.Add(Txtmail.Text);
            msg.Subject = "Welcome to Ramco !";
            msg.Body = ("Your Username is:" + code + "<br/><br/>" + "Your Password is:" + pwd);
            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "aswajith.1702063@srec.ac.in"; //Your Email ID  
            ntwd.Password = "919944902340"; // Your Password  
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
           


            cmd.ExecuteNonQuery();
            con.Close();
           
            Response.Write("<script>alert('Sign Up Successful. Please check your mail For Login Credentials');</script>");
            clear();





        }
    }
}