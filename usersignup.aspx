﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="ElibraryManagement.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col"> 
                                <center><img width="100" src="imgs/generaluser.png" /> 
                                </center>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col">
                            <center>
                                <h4>Member Sign Up</h4>
                            </center>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        
                    </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="fullname" runat="server" placeholder="full name"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="datebirth" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ContactNumber" runat="server" placeholder="Contact number" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailID" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                 <div class="form-group">
                                        <asp:DropDownList class="form-control" ID="state" runat="server">
                                            <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                                            <asp:ListItem Text="Andaman and Nicobar Islands" Value="Andaman and Nicobar Islands" />
                                            <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                            <asp:ListItem Text="Assam" Value="Assam" />
                                            <asp:ListItem Text="Bihar" Value="Bihar" />
                                            <asp:ListItem Text="Chandigarh" Value="Chandigarh" />
                                            <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                                            <asp:ListItem Text="Dadar and Nagar Haveli" Value="Dadar and Nagar Haveli" />
                                            <asp:ListItem Text="Daman and Diu" Value="Daman and Diu" />
                                            <asp:ListItem Text="Delhi" Value="Delhi" />
                                            <asp:ListItem Text="Lakshadweep" Value="Lakshadweep" />
                                            <asp:ListItem Text="Puducherry" Value="Puducherry" />
                                            <asp:ListItem Text="Goa" Value="Goa" />
                                            <asp:ListItem Text="Gujarat" Value="Gujarat" />
                                            <asp:ListItem Text="Haryana" Value="Haryana" />
                                            <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                            <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                                            <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                            <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                            <asp:ListItem Text="Kerala" Value="Kerala" />
                                            <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                            <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                            <asp:ListItem Text="Manipur" Value="Manipur" />
                                            <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                                            <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                            <asp:ListItem Text="Nagaland" Value="Nagaland" />
                                            <asp:ListItem Text="Odisha" Value="Odisha" />
                                            <asp:ListItem Text="Punjab" Value="Punjab" />
                                            <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                            <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                            <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                            <asp:ListItem Text="Telangana" Value="Telangana" />
                                            <asp:ListItem Text="Tripura" Value="Tripura" />
                                            <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                            <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                            <asp:ListItem Text="West Bengal" Value="West Bengal" />              
                                        </asp:DropDownList>
                                    </div>
                            </div>
                             <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="City" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="pincode" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="FullAddress" runat="server" placeholder="full address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                           <div class="col-6 mx-auto">
                            <center>
                                <asp:Label class="badge-pill bg-primary" id="Label1" Text="Login Credentials" runat="server" />
                            </center>
                        </div>  
                        </div>
                      
                         <div class="row">
                            <div class="col-md-6">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="memberid" runat="server" placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Create Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="password" runat="server" placeholder="Password" TextMode="password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-7 mx-auto">
                                  <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="signup" runat="server" text="Sign Up" OnClick="signup_Click"></asp:Button>
                                </div></center>
                            </div>
                             
                        </div>
                         <a href="homepage.aspx"><-- Back to Home Page</a>
                    </div>
                </div>
            </div>

        </div>

    </div>


</asp:Content>
