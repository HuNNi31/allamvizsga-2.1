<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adattipus.aspx.cs" Inherits="MVCLogin.ASPX.RDLC_ReportTutorial1"  %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<script src="https://code.jquery.com/jquery-1.10.2.js"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adattipusok</title>
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

                        <li> <a class="active" runat="server" href="~/Home/Index">Home</a></li>

                        <!--ASPX linkek-->
                        <li>
                            <a runat="server" href="~/ASPX/users.aspx">Users</a>
                        </li>
                        <li>
                            <a runat="server" href="~/ASPX/Default.aspx"> Tanárok</a>
                        </li>

                        <li>
                            <a href="#">Tablazatok</a>

                            <ul class="dropdown">
                                <li><a runat="server" href="~/ASPX/Adattipus.aspx">Adattipusok</a></li>
                               
                                <li><a runat="server" href="~/ASPX/szakok.aspx"> Szakok</a> </li>
                                <li><a runat="server" href="~/ASPX/egyetem.aspx"> Egyetem</a> </li>

                            </ul>
                        </li>
                        <li>
                            <a runat="server" href="~/Import/Index">Import</a>
                        </li>

                        <li>
                            <a runat="server" href="~/Home/Profil">Profil</a>
                        </li>

                        <li class="last">

                            <a runat="server" href="~/Login/Index">Log Out</a>


                        </li>

                    </ul>
                </div>
            </nav>
      
        <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>
    </header>
    <form id="form1" runat="server">
         <div style="height: 624px; align-content:center>
        <asp:Panel ID="Panel1" runat="server">
   
            <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="99%" Height="94%" >

            </rsweb:ReportViewer>
        
              </asp:Panel>


        </div>
     </form>
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>

</body>

</html>
