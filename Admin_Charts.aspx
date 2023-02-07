<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_Charts.aspx.cs" Inherits="AdvancedWebDevelopment.Admin_Charts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  
    <table>
        <tr>
            <td>

            </td>
            <td>
                <div id ="MyLineChart"></div>
            </td>
        </tr>
    </table>

    <script src="http://code.highcharts.com/highcharts.js"></script>
    <script>
        $('#MyLineChart').highcharts({
            chart: {
                type: 'spline'
            },
            title: {
                text: 'Monthly High Temp Counts'
            },
            xAxis: {
                title: {
                    text: 'Month'
                }
            },
            yAxis: {
                title: {
                    text: 'Count'
                }
            },
            series: [{
                type: 'spline',
                name: 'Monthly High Temp',
                data: <%=lineData%>,
            }]

        })
    </script>
     <asp:GridView ID="gvLineChart" runat="server">
    </asp:GridView>
</asp:Content>
