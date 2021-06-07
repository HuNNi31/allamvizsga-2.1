<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MVCLogin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import manually</title>
        <link rel="stylesheet" type="text/css" href="~/Content/styles.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/table_style.css" />
     <link rel="stylesheet" type="text/css" href="~/Content/style.css" />
    <link rel="stylesheet"
          href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Quicksand:wght@300;400;500;600;700&display=swap"
          rel="stylesheet" />
    
</head>
<body>
                <header>
                     </div>

            <nav>

                <ul>

                    <li> <a class="active" runat="server" href="~/Home/Index">Home</a></li>

                    <!--ASPX linkek-->
                    <li>
                        <a runat="server" href="~/RDLC_ReportTutorial.aspx">Users</a>
                    </li>
                    <li>
                        <a runat="server" href="~/Adattipus.aspx">Adattipusok</a>
                    </li>

                    <li> <a href="#">Tablazatok</a>
                        
                        <ul class="dropdown">
                            
                            <li><a runat="server" href="~/Default.aspx">TanarTablazat</a> </li>
                            <li><a runat="server" href="~/szakok.aspx"> Szakok</a> </li>
                            <li><a runat="server" href="~/egyetem.aspx"> Egyetem</a> </li>
                            <li><a runat="server" href="~/egyetem.aspx"> Egyetem2</a> </li>
                            
                        </ul>
                    </li>
                    <li>
                        <a runat="server" href="~/Import/Index">Import</a>
                    </li>

                    <li>
                        <a runat="server" href="~/Home/Profil">Profil</a>
                    </li>
                    
                    <li >
                       
                         <a runat="server" href="~/Login/Index">Log Out</a>
    
                           
                    </li>
                    
                </ul>
            </nav>
        </div>
                    </header>
        <%--var result = new ControllerB().FileUploadMsgView("some string");--%>
        <h2> Excel Import</h2>
        <form method="post" enctype="multipart/form-data">
            <div>
                <input name="file" type="file" required />
                <button type="submit">Import</button>
            </div>
        </form>
    </div>
    <form id="form1" runat="server">
        <div class="table">

            <asp:GridView ID="gvTanar" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" ShowFooter="true" DataKeyNames="F1"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvTanar_RowCommand" OnRowEditing="gvTanar_RowEditing" OnRowCancelingEdit="gvTanar_RowCancelingEdit"
                OnRowUpdating="gvTanar_RowUpdating" OnRowDeleting="gvTanar_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#194d2f" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#256E43" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("F1") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF1" Text='<%# Eval("F1") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF1Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tanár Neve">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("F2") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF2" Text='<%# Eval("F2") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF2Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tanszék">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("F3") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF3" Text='<%# Eval("F3") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF3Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Órák száma">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("F4") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF4" Text='<%# Eval("F4") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF4Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>