<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_Charts.aspx.cs" Inherits="AdvancedWebDevelopment.Admin_Charts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.3.min.js" integrity="sha256-pvPw+upLPUjgMXY0G+8O0xUf+/Im1MZjXxxgOcBQBXU=" crossorigin="anonymous"></script>
    <script src="Scripts/highcharts/7.1.2/highcharts.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <table>
        <tr>
            <td>
                <div id ="MyLineChart"></div>
            </td>
            <td>
                <div id ="MyColumnChart"></div>

            </td>
            <td>
 
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
                text: 'Monthly Profits'
            },
            xAxis: {
                title: {
                    text: 'Month'
                },
                max: 7
            },
            yAxis: {
                title: {
                    text: 'Profit'
                }
            },
            series: [{
                type: 'spline',
                name: 'Monthly Profits',
                data: <%=lineData2%>,
            }]

        })
    </script>
     <asp:GridView ID="gvLineChart" runat="server" Visible="false">
                </asp:GridView>
    <script>
        $('#MyColumnChart').highcharts({
            chart: {
                type: 'column'
            },
            title: {
                text: 'Total Items Sold'
            },
            xAxis: {
                categories: [
                    'Jan',
                    'Feb',
                    'Mar',
                    'Apr',
                    'May',
                    'Jun',
                    'Jul',
                    'Aug',
                    'Sep',
                    'Oct',
                    'Nov',
                    'Dec'
                ],
                crosshair: true
            },


            yAxis: {
                min: 0,
                title: {
                    text: 'Items Sold'
                }
            },
            tooltip: {
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    '<td style="padding:0"><b>{point.y:.0f} </b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                }
            },

            series: [{
                name: 'Shoes',
                data: <%=shoeData%>
            }, {
                name: 'Shirts',
                data: <%=shirtData%> 
            }, {
                name: 'Assessories',
                data: <%=ass%>
            }]

        })
    </script>
</asp:Content>
