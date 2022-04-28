<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MVCLogin.ASPX.Default" %>

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


        <nav>
            <div>
                <ul>

                    <li><a class="active" runat="server" href="~/Home/Index">Főmenü</a></li>

                    <!--ASPX linkek-->
                    <li>
                        <a runat="server" href="~/ASPX/users.aspx">Felhasználók</a>
                    </li>
                    <li>
                        <a runat="server" href="~/ASPX/Default.aspx">Diákok</a>
                    </li>

                    <li>
                        <a href="#">Tablazatok</a>

                        <ul class="dropdown">
                            <li><a runat="server" href="~/ASPX/Adattipus.aspx">Diák jelentés</a></li>
                            <li><a runat="server" href="~/ASPX/szakok.aspx">Szakok</a> </li>
                            <li><a runat="server" href="~/ASPX/egyetem.aspx">Egyetem</a> </li>

                        </ul>
                    </li>
                    <li>
                        <a runat="server" href="~/Import/Index">Import</a>
                    </li>

                    <li>
                        <a runat="server" href="~/Home/Profil">Profil</a>
                    </li>

                    <li class="last">

                        <a runat="server" href="~/Login/Index">Kijelentkezés</a>


                    </li>

                </ul>
            </div>
        </nav>

        <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>
    </header>


    <h2> Diák Táblázat</h2>
    <form id="form1" runat="server">
        <div class="table">

            <asp:GridView ID="gvTanar" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" ShowFooter="true" DataKeyNames="ID"
                ShowHeaderWhenEmpty="true"
                OnRowCommand="gvTanar_RowCommand" OnRowEditing="gvTanar_RowEditing" OnRowCancelingEdit="gvTanar_RowCancelingEdit"
                OnRowUpdating="gvTanar_RowUpdating" OnRowDeleting="gvTanar_RowDeleting"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Design beállítások --%>
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
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF1" Text='<%# Eval("ID") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF1Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Képzés">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Szakok") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF2" Text='<%# Eval("Szakok") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF2Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Szak vezető tanár neve">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("TanarCim") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF3" Text='<%# Eval("TanarCim") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF3Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Diák neve">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("TanarNev") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF4" Text='<%# Eval("TanarNev") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF4Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Jelentkezés éve">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("TanariAllas") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF5" Text='<%# Eval("TanariAllas") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF5Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Aktivitás">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Aktivitas") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF6" Text='<%# Eval("Aktivitas") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF6Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Elégedettségi tényező">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Gradul_de_multumire") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtF7" Text='<%# Eval("Gradul_de_multumire") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtF7Footer" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
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
