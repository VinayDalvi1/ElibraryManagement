<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="ElibraryManagement.viewbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
     $(document).ready(function () {
         $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
     });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="col-md-10 mx-auto">

                <div class="card">
                    <div class="card-body">
                          
                <div class="row">
                    <div class="col">
                        <center>
                            <h3>Books Inventory List</h3>
                            <p>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            </p>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                 <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                         <ControlStyle Font-Bold="True" />
                         <ItemStyle Font-Bold="True" />
                      </asp:BoundField>
                               <%-- <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                <asp:BoundField DataField="publisher_date" HeaderText="publisher_date" SortExpression="publisher_date" />
                                <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                <asp:BoundField DataField="no_of_pages" HeaderText="no_of_pages" SortExpression="no_of_pages" />
                                <asp:BoundField DataField="book_description" HeaderText="book_description" SortExpression="book_description" />
                                <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                <asp:BoundField DataField="book_img_link" HeaderText="book_img_link" SortExpression="book_img_link" />--%>
                               <asp:TemplateField>
                         <ItemTemplate>
                            <div class="container-fluid">
                               <div class="row">
                                  <div class="col-lg-10">
                                     <div class="row">
                                        <div class="col-12">
                                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                        </div>
                                     </div>
                                     <div class="row">
                                        <div class="col-12">
                                           <span>Author - </span>
                                           <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                           &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                           <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                           &nbsp;| 
                                           <span>
                                              Language -<span>&nbsp;</span>
                                              <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                           </span>
                                        </div>
                                     </div>
                                     <div class="row">
                                        <div class="col-12">
                                           Publisher -
                                           <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                           &nbsp;| Publish Date -
                                           <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publisher_date") %>'></asp:Label>
                                           &nbsp;| Pages -
                                           <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                           &nbsp;| Edition -
                                           <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                        </div>
                                     </div>
                                     <div class="row">
                                        <div class="col-12">
                                           Cost -
                                           <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                           &nbsp;| Actual Stock -
                                           <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                           &nbsp;| Available Stock -
                                           <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                        </div>
                                     </div>
                                     <div class="row">
                                        <div class="col-12">
                                           Description -
                                           <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                        </div>
                                     </div>
                                  </div>
                                  <div class="col-lg-2">
                                     <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                  </div>
                               </div>
                            </div>
                         </ItemTemplate>
                      </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
     
                     <a href="homepage.aspx"><-- Back to Home Page</a>
                </div>
            </div>
</asp:Content>
