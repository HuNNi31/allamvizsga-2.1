<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="szakok.aspx.cs" Inherits="MVCLogin.szakok" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Szakok</title>
    <link rel="stylesheet" type="text/css" href="~/Content/styles.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/table_style.css" />
    <link rel="stylesheet"
          href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.13.0/css/all.min.css" />
    <link href="https://fonts.googleapis.com/css2?family=Quicksand:wght@300;400;500;600;700&display=swap"
          rel="stylesheet" />
</head>
<body> 
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
            

    <form id="form1" runat="server">
        <div style="height: 196px">
        <asp:Panel ID="Panel1" runat="server">
            <%--int width = (Request.Browser.ScreenPixelsWidth) * 2 - 100;
            int height = (Request.Browser.ScreenPixelsHeight) * 2 - 100;--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="833px"  >

            </rsweb:ReportViewer>
              
 
              </asp:Panel>


        </div>
     </form>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

</body>

</html>
