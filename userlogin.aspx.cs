﻿using System;
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
    public partial class userlogin : System.Web.UI.Page
    {
        string on = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void login_Click(object sender, EventArgs e)

        {
            try
            {
                SqlConnection con = new SqlConnection(on);
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='"+memberid.Text.Trim()+"' AND password='"+password.Text.Trim()+"'", con);

               SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('"+dr.GetValue(8).ToString()+"');</script>");
                        Session["Username"]=dr.GetValue(8).ToString();
                        Session["fullname"]=dr.GetValue(0).ToString();
                        Session["role"]="user";
                        Session["status"]=dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('invalid credentials');</script>");
                }
                

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

           // Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");



        }
    }
}