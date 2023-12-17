<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="membermanagement.aspx.cs" Inherits="ElibraryManagement.membermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(Document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-10 ">
                <div class="card">
                    <div class="card-body">
                          <div class="row">
                        <div class="col">
                            <center>
                                <h4>User Profile</h4>
                            </center>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        
                    </div>
                        <div class="row">
                            <div class="col"> 
                                <center><img width="100" src="imgs/generaluser.png" /> 
                                </center>
                            </div>
                        </div>
                      
                        
                        <div class="row">
                             <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group ">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="memberid" runat="server" placeholder="ID"></asp:TextBox>
                                         <asp:LinkButton class="btn btn-primary" ID="search" runat="server" text="Go" OnClick="search_Click" ><i class="fas fa-check-circle" ></i></asp:LinkButton>
                                        </div>
                                </div>
                            </div>
                            <div class="col-3">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="fullname" runat="server" placeholder="full name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Account Status</label>
                                <div class="form-group ">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="acstatus" runat="server" placeholder="Account Status" ReadOnly="true"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success mr-1" ID="check" runat="server" text="Go" OnClick="check_Click"><i class="fas fa-check-circle" ></i></asp:LinkButton>
                                         <asp:LinkButton class="btn btn-warning mr-1" ID="pause" runat="server" text="Go" OnClick="pause_Click"><i class="far fa-pause-circle" ></i></asp:LinkButton>
                                         <asp:LinkButton class="btn btn-danger mr-1" ID="desable" runat="server" text="Go" OnClick="desable_Click"><i class="fas fa-times-circle" ></i></asp:LinkButton>
                                        </div>
                                </div>
                            </div>

                        </div>
                         <div class="row">
                              <div class="col-md-4">
                                <label>Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="datebirth" runat="server" placeholder="Date of Birth" TextMode="Date" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="ContactNumber" runat="server" placeholder="Contact number" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="EmailID" runat="server" placeholder="Email ID" TextMode="Email" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="state" runat="server" placeholder="State" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="City" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="pincode" runat="server" placeholder="Pin Code" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="FullAddress" runat="server" placeholder="full address" TextMode="MultiLine" Rows="2" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                         <div class="row">
                            <div class="col-md-9 mx-auto">
                                  <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block btn-lg" ID="delete" runat="server" text="Delete Member Account" OnClick="delete_Click"></asp:Button>
                                </div></center>
                            </div>
                             
                        </div>
                         <a href="homepage.aspx"><-- Back to Home Page</a>
                          <br />
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                    </div>
                </div>
            </div> 

            <div class="col-md-">

                  <div class="card">
                    <div class="card-body">
                        <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member List</h3>
                            </center>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                     <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                    <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                                    <asp:BoundField DataField="account_status" HeaderText="status" SortExpression="account_status" />
                                    <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                    <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                                    <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                   
                                  
                                   
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    </div>
                </div>
            </div>

        </div>

    </div>
</asp:Content>
