<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="ElibraryManagement.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                        <div class="col">
                            <center>
                                <h4>Book Issuing</h4>
                            </center>
                        </div>                        
                    </div>
                        <div class="row">
                            <div class="col"> 
                                <center><img width="80" src="imgs/books1.png" /> 
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="memberid" runat="server" placeholder="member id"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group ">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="bookid" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-info" ID="go" runat="server" text="Go" OnClick="go_Click"></asp:Button>
                                        </div>
                                </div>
                            </div>

                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="membername" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="bookname" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="startadte" runat="server" Textmode="Date"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Returning Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="duedate" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                         <div class="row">
                            <div class="col-md-6">
                                  <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="issue" runat="server" text="Issue" OnClick="issue_Click"></asp:Button>
                                </div></center>
                            </div>
                             <div class="col-md-6">
                                  <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-info btn-block btn-lg" ID="return" runat="server" text="Return" OnClick="return_Click"></asp:Button>
                                </div></center>
                            </div>
                             
                        </div>
                         <a href="homepage.aspx"><-- Back to Home Page</a>
                    </div>
                </div>
            </div> 

            <div class="col-md-7">

                  <div class="card">
                    <div class="card-body">
                        <div class="row">
                        <div class="col">
                            <center>
                                <h3>Your Issued Books</h3>
                            </center>
                        </div>
                    </div>
                     <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:elibraryDBConnectionString %>' SelectCommand="SELECT * FROM [book_issue_tbl]">
											</asp:SqlDataSource>
											<div class="col">
												<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
													<Columns>
														<asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id"></asp:BoundField>
														<asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name"></asp:BoundField>
														<asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id"></asp:BoundField>
														<asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name"></asp:BoundField>
														<asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date"></asp:BoundField>
														<asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date"></asp:BoundField>
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
