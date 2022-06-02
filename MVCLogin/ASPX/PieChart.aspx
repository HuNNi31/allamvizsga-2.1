<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PieChart.aspx.cs" Inherits="MVCLogin.ASPX.PieChart"  %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PieChart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSourcePie" Width="283px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Pie" XValueMember="Tanszek" YValueMembers="Szint">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:SqlDataSource ID="SqlDataSourcePie" runat="server" ConnectionString="<%$ ConnectionStrings:minosegbiztositasConnectionStringPie %>" SelectCommand="SELECT Tanszek, AVG(Gradul_de_multumire) AS Szint FROM Adattipus GROUP BY Tanszek"></asp:SqlDataSource>
 </div>
        <div>
            <asp:GridView ID="GridView1" runat="server">
                <RowStyle ForeColor="Black" />
            </asp:GridView>
        </div>


        
    </form>
</body>
</html>
