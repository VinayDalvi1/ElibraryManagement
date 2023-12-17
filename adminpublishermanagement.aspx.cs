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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          GridView1.DataBind();
        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {

                Response.Write("<script>alert('publisher with this ID Already Exists');</script>");
            }
            else
            {
                addNewPublisher();
            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();

            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID Dose not Exists');</script>");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();

            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID Dose not Exists');</script>");
            }
        }

        protected void go_Click(object sender, EventArgs e)
        {
            getPublisherGo();
        }

        void getPublisherGo()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + publisherid.Text.Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    publishername.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }
        void clearform()
        {
            publisherid.Text = "";
            publishername.Text = "";
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("DELETE from publisher_master_tbl WHERE publisher_id='" + publisherid.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Publisher Deleted successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + publisherid.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@publisher_id", publisherid.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", publishername.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Publisher Updated successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", publisherid.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", publishername.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Redirect("test.aspx");

                Response.Write("<script>alert('Publisher added successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);


                con.Open();


                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + publisherid.Text.Trim() + "';", con);

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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;

            }
        }

    }
}