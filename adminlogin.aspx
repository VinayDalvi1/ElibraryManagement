<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ElibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <center>
                          <<img width="150" src="imgs/adminuser.png" />
                          <div class="card-body">
                            <h4 class="card-title">Admin Login</h4>
                            
                          </div>
                        </center>
                </div>  
                
            </div>
        </div>
       
       
            <div class="col-md-5 mx-auto">
                <div class="card">
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Admin ID" ID="adminid" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Password" ID="apassword" TextMode="password" ></asp:TextBox>
                        </div>
                </div>  
            </div>
        
        
  
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <center>
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="login" text="Login" Width="200" OnClick="login_Click"></asp:Button>
                        </div>
                        <div class="form-group">
                           
                        </center>

                     <a href="homepage.aspx"><-- Back to Home Page</a>
                </div>  
             
      </div>  

    </div>

</asp:Content>
