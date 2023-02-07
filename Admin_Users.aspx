<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_Users.aspx.cs" Inherits="AdvancedWebDevelopment.Admin_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Style for the gridview container */
        .GVcontainer {
            height: auto;
            width: 70%;
            margin: auto;
            margin-bottom: 40px;
            margin-top: 40px;
            display:flex;
        }
        
        /* Style for the gridview */
        .gvUsers {
            font-family: Arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
        
        /* Style for the gridview header */
        .gvUsers th {
            background-color: black;
            color: white;
            padding: 10px;
            text-align: left;
        }
        
        /* Style for the gridview rows */
        .gvUsers td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        
        /* Style for the gridview rows on hover */
        .gvUsers tr:hover {
            background-color: #f2f2f2;
        }
        
        /* Media queries for responsive styling */
        @media (max-width: 400px) {
            .GVcontainer {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="GVcontainer">
        <asp:GridView ID="gvUsers" CssClass="gvUsers" runat="server" AutoGenerateColumns="False" Height="261px" Width="1072px" AllowPaging="True" DataKeyNames="customerId" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" OnRowDeleting="gvUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="customerId" HeaderText="customerId" ReadOnly="True" SortExpression="customerId" InsertVisible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="phoneNo" HeaderText="phoneNo" SortExpression="phoneNo" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [customerId], [name], [email], [phoneNo] FROM [Customers]"></asp:SqlDataSource>
    </div>
    
</asp:Content>