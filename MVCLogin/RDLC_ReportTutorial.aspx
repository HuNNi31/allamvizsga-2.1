<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RDLC_ReportTutorial.aspx.cs" Inherits="MVCLogin.RDLC_ReportTutorial" %>

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
            <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="922px">
              <%--  <LocalReport ReportEmbeddedResource="MVCLogin.ReportUni.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2" />
                    </DataSources>
                </LocalReport>--%>
            </rsweb:ReportViewer>
           <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="userDataSetTableAdapters.LoginABTableAdapter"></asp:ObjectDataSource>--%>
              </asp:Panel>
        </div>
    </form>
</body>
</html>
