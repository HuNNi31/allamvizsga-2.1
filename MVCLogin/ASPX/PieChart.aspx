<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PieChart.aspx.cs" Inherits="MVCLogin.ASPX.PieChart"  %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PieChart</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

           <asp:Chart ID="Chart1" runat="server" BackColor="0, 0, 64" BackGradientStyle="LeftRight"  
        BorderlineWidth="0" Height="360px" Palette="None" PaletteCustomColors="Maroon"  
        Width="546px" BorderlineColor="64, 0, 64">  
        <Titles>  
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>  
        <Series>  
            <asp:Series Name="Default" />  
        </Series>  
        <ChartAreas>  
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />  
        </ChartAreas>  
    </asp:Chart>  
 </div>
        <div>
            <asp:GridView ID="GridView1" runat="server">
                <RowStyle ForeColor="Black" />
            </asp:GridView>
        </div>


        
    </form>
</body>
</html>
