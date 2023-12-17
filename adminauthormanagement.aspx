<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ElibraryManagement.adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(Document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/writer.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group ">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="authorid" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-secondory" ID="go" runat="server" Text="Go" OnClick="go_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="authorname" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="add" runat="server" Text="Add" OnClick="add_Click"></asp:Button>
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="update" runat="server" Text="Update" OnClick="update_Click"></asp:Button>
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="delete" runat="server" Text="Delete" OnClick="delete_Click"></asp:Button>
                            </div>
                        </div>
                        <a href="homepage.aspx"><-- Back to Home Page</a>
                    </div>
                </div>
            </div>

            <div class="col-md-6">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Authors Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
