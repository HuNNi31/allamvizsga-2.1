<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adattipus.aspx.cs" Inherits="MVCLogin.RDLC_ReportTutorial1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        body {
             background: #256E43;
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
    #form1 {
        background-color: white;
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
            <a class="last" runat="server" href="~/Home/Profil">Back</a>
            <a class="last" runat="server" href="~/Login/Index">Profil</a>
     

        </div>
    </div>
  
    <form id="form1" runat="server">
        <div style="height: 196px">
        <asp:Panel ID="Panel1" runat="server">
            <%--int width = (Request.Browser.ScreenPixelsWidth) * 2 - 100;
            int height = (Request.Browser.ScreenPixelsHeight) * 2 - 100;--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="547px">

            </rsweb:ReportViewer>
                   <!--Chheckbox megoldas filter-->
   
   <asp:CheckBox ID="chkName" Text="ID" runat="server" OnCheckedChanged="OnCheckedChanged"
    AutoPostBack="true" Checked="true" />
<asp:CheckBox ID="chkCountry" Text="Tanar Fizetes" runat="server" OnCheckedChanged="OnCheckedChanged"
    AutoPostBack="true" Checked="true" />
<hr />
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("ID") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country">
            <ItemTemplate>
                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Tanar Fizetes") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCountry" runat="server" Text='<%# Eval("Tanar Fizetes") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:Button ID="btnShow" Text="Show In New Window" runat="server" OnClick="ShowRDLC" />
        <%--Eddig--%>
              </asp:Panel>


        </div>
     </form>
</body>
</html>
