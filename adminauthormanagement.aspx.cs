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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {

                Response.Write("<script>alert('Author with this ID Already Exists');</script>");
            }
            else
            {
                addNewAuthor(); 
            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
               
            }
            else
            {
                Response.Write("<script>alert('Author with this ID Dose not Exists');</script>");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();

            }
            else
            {
                Response.Write("<script>alert('Author with this ID Dose not Exists');</script>");
            }
        }

        protected void go_Click(object sender, EventArgs e)
        {
            getAthorGo();
        }

        void getAthorGo()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + authorid.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    authorname.Text = dt.Rows[0][1].ToString();  
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                

            }
        }
        void clearform()
        {
            authorid.Text = "";
            authorname.Text = "";
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("DELETE from author_master_tbl WHERE author_id='" + authorid.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Author Deleted successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+ authorid.Text.Trim() +"'", con);
                cmd.Parameters.AddWithValue("@author_id", authorid.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", authorname.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Author Updated successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) values(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", authorid.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", authorname.Text.Trim());
               

                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Author added successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + authorid.Text.Trim() + "';", con);

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


    }
}