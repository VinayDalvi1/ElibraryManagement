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
    public partial class membermanagement : System.Web.UI.Page
    {
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void search_Click(object sender, EventArgs e)
        {
           
            getmemberbyid();
        }
        protected void check_Click(object sender, EventArgs e)
        {
            statusupdate("active");
        }
        protected void pause_Click(object sender, EventArgs e)
        {
            statusupdate("pending");
        }
        protected void desable_Click(object sender, EventArgs e)
        {
            statusupdate("deactive");
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            deletuser();
        }

        void getmemberbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '" + memberid.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fullname.Text = dr.GetValue(0).ToString();
                        acstatus.Text = dr.GetValue(10).ToString();
                        datebirth.Text = dr.GetValue(1).ToString();
                        ContactNumber.Text = dr.GetValue(2).ToString();
                        EmailID.Text = dr.GetValue(3).ToString();
                        state.Text = dr.GetValue(4).ToString();
                        City.Text = dr.GetValue(5).ToString();
                        pincode.Text = dr.GetValue(6).ToString();
                        FullAddress.Text = dr.GetValue(7).ToString();

                    }

                }
                else
                {
                    Response.Write("<script>alert('invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void statusupdate(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' where member_id ='" + memberid.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('status update successfull');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deletuser()
        {
            if(memberid.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('Plese enter the member ID ');</script>");
            }
            else { 
                try
                {
                    SqlConnection con = new SqlConnection(on);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl where member_id ='" + memberid.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('account Deleted successfull');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
        }
    }
}