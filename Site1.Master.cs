using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["role"] == null)
                    {
                        userlogin.Visible = true;
                        signup.Visible = true;

                        logout.Visible = false;
                        hellouser.Visible = false;

                        adminlogin.Visible = true;
                        authormanagement.Visible = false;
                        publishermanagment.Visible = false;
                        booksinventory.Visible = false;
                        bookissuing.Visible = false;
                        membermanagement.Visible = false;
                    }
                    else if (Session["role"].Equals("user"))
                    {
                        userlogin.Visible = false;
                        signup.Visible = false;

                        logout.Visible = true;
                        hellouser.Visible = true;
                        hellouser.Text = "hello" + Session["username"].ToString();

                        adminlogin.Visible = true;
                        authormanagement.Visible = false;
                        publishermanagment.Visible = false;
                        booksinventory.Visible = false;
                        bookissuing.Visible = false;
                        membermanagement.Visible = false;
                    }
                    else if (Session["role"].Equals("admin"))
                    {
                        userlogin.Visible = false;
                        signup.Visible = false;

                        logout.Visible = true;
                        hellouser.Visible = true;
                        hellouser.Text = "hello admin";

                        adminlogin.Visible = false;
                        authormanagement.Visible = true;
                        publishermanagment.Visible = true;
                        booksinventory.Visible = true;
                        bookissuing.Visible = true;
                        membermanagement.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void adminlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void authormanagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void publishermanagment_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void booksinventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("booksinventory.aspx");
        }

        protected void bookissuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void membermanagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("membermanagement.aspx");
        }

        protected void viewbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void userlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            userlogin.Visible = true; // user login link button
            signup.Visible = true; // sign up link button

            logout.Visible = false; // logout link button
            hellouser.Visible = false; // hello user link button


            adminlogin.Visible = true; // admin login link button
            authormanagement.Visible = false; // author management link button
            publishermanagment.Visible = false; // publisher management link button
            booksinventory.Visible = false; // book inventory link button
            bookissuing.Visible = false; // book issuing link button
            membermanagement.Visible = false; // member management link button
        }

        protected void hellouser_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }



    }
}