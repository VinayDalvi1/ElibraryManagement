using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ElibraryManagement
{
    public partial class booksinventory : System.Web.UI.Page
    {
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAuthorPublisherValues();
            }

            GridView1.DataBind();
        }

        // go button click
        protected void search_Click(object sender, EventArgs e)
        {
            getBookByID();
        }


        // update button click
        protected void bupdate_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        // delete button click
        protected void bdelete_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }
        // add button click
        protected void badd_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                addNewBook();
            }
        }



        // user defined functions

        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(on);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + bookid.Text.Trim() + "'", con) ;

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void updateBookByID()
        {

            if (checkIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(Astock.Text.Trim());
                    int current_stock = Convert.ToInt32(Cstock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            Cstock.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in genre1.GetSelectedIndices())
                    {
                        genres = genres + genre1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/BoookInventory/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("BookInventory/" + filename));
                        filepath = "~/BookInventor/" + filename;
                    }

                    SqlConnection con = new SqlConnection(on);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publisher_date=@publisher_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + bookid.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", fullname.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", Authorname.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", publisher.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_date", pdate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", language.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", edition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", cost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", pages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", Summary.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }


        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='" + bookid.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    fullname.Text = dt.Rows[0]["book_name"].ToString();
                    pdate.Text = dt.Rows[0]["publisher_date"].ToString();
                    edition.Text = dt.Rows[0]["edition"].ToString();
                    cost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    pages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    Astock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    Cstock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    Summary.Text = dt.Rows[0]["book_description"].ToString();
                    Ibook.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    language.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    publisher.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    Authorname.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    genre1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < genre1.Items.Count; j++)
                        {
                            if (genre1.Items[j].ToString() == genre[i])
                            {
                                genre1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"]);
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"]);
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Authorname.DataSource = dt;
                Authorname.DataValueField = "author_name";
                Authorname.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_table;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                publisher.DataSource = dt;
                publisher.DataValueField = "publisher_name";
                publisher.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + bookid.Text.Trim() + "' OR book_name='" + fullname.Text.Trim() + "';", con);
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

        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in genre1.GetSelectedIndices())
                {
                    genres = genres + genre1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/BookInventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("BookInventory/" + filename));
                filepath = "~/BookInventory/" + filename;


                SqlConnection con = new SqlConnection(on);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publisher_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publisher_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", bookid.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", Authorname.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", publisher.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_date", pdate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", language.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", cost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", Summary.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", Astock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", Cstock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}