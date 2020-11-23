<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RDLC_ReportTutorial1.aspx.cs" Inherits="MVCLogin.RDLC_ReportTutorial1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 196px">
        <asp:Panel ID="Panel1" runat="server">
            <%--int width = (Request.Browser.ScreenPixelsWidth) * 2 - 100;
            int height = (Request.Browser.ScreenPixelsHeight) * 2 - 100;--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1376px" Height="547px">
                <LocalReport ReportEmbeddedResource="MVCLogin.Reports.rptMunka1.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Munka1DataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="MunkaDataSetTableAdapters.Munka1_TableAdapter"></asp:ObjectDataSource>
           <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="userDataSetTableAdapters.LoginABTableAdapter"></asp:ObjectDataSource>--%>
              </asp:Panel>
        </div>
    </form>
</body>
</html>
