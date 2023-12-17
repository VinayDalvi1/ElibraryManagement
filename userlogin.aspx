<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ElibraryManagement.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <center>
                          <<img width="150" src="imgs/generaluser.png">
                          <div class="card-body">
                            <h4 class="card-title">Member Login</h4>
                            
                          </div>
                        </center>
                </div>  
                
            </div>
        </div>
       
       
            <div class="col-md-5 mx-auto">
                <div class="card">
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="member ID" ID="memberid" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" runat="server" placeholder="Password" ID="password" TextMode="Password" ></asp:TextBox>
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
                            <a href="usersignup.aspx">
                            <asp:TextBox CssClass="btn btn-info" runat="server" ID="signup" text="Sign Up" ></asp:TextBox></a>
                        </div>
                        </center>

                     <a href="homepage.aspx"><-- Back to Home Page</a>
                </div>  
             
      </div>  

    </div>
</asp:Content>
