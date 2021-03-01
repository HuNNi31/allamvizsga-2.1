<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MVCLogin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background: #76b852;
        }
            /* Add a black background color to the top navigation */
        .topnav {
            background-color: #333;
            overflow: hidden;
        }

            /* Style the links inside the navigation bar */
            .topnav a {
                float: left;
                color: #f2f2f2;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
                font-size: 17px;
            }

                /* Change the color of links on hover */
                .topnav a:hover {
                    background-color: #ddd;
                    color: black;
                }

                /* Add a color to the active/current link */
                .topnav a.active {
                    background-color: darkred;
                    color: white;
                }
                .topnav a.last{
                    float:right;
                }
         .table {
              margin-left: auto;
              margin-right: auto;
         }
    </style>
    
</head>
<body>
         <div>
        <h1>Dashboard</h1>
       
        <div class="topnav">

            <a class="active" runat="server" href="~/Home/Index">Home</a>
                <!--ASPX linkek-->
                <a runat="server" href="~/RDLC_ReportTutorial.aspx">ToReport1</a>
                <a runat="server" href="~/Adattipus.aspx">AdattipusokRDLC</a>
                <a runat="server" href="~/Default.aspx">TanarTablazat</a>
                <!--ASPX linkek vége-->
            <a class="last" runat="server" href="~/Home/Index">Back</a>
            <a class="last" runat="server" href="~/Home/Profil">Profil</a>
     

        </div>
    </div>
    <form id="form1" runat="server">
        <div class="table">

            <asp:GridView ID="gvTanar" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="F1"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvTanar_RowCommand" OnRowEditing="gvTanar_RowEditing" OnRowCancelingEdit="gvTanar_RowCancelingEdit"
                OnRowUpdating="gvTanar_RowUpdating" OnRowDeleting="gvTanar_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="F1">
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
                    <asp:TemplateField HeaderText="F2">
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
                    <asp:TemplateField HeaderText="F3">
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
                    <asp:TemplateField HeaderText="F4">
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