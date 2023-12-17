using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{

    public partial class usersignup : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // sign up button click
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void signup_Click(object sender, EventArgs e)
        {
            if(CheckMemberExist())
            {
                Response.Write("<script>alert('Member Already Exist with this Member ID, try Other ID');</script>");
            }
            else
            {
                signUpNewUser();
            } 

        }

        bool CheckMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='"+memberid.Text.Trim()+"';", con);

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


               
                con.Close();

                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;

            }

        }
        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status)" +
                   " values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", datebirth.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", ContactNumber.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailID.Text.Trim());
                cmd.Parameters.AddWithValue("@state", state.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", pincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", FullAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", memberid.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}