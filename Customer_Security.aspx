<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_Security.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_Security" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 
    <div class="contact-box-main">
        <div class="container">
            <div class="row">
      
                <div class="col-lg-12 col-sm-12">
                    <div class="contact-form-right">
                        <h2>Security Questions</h2>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                              <asp:ListItem Value="What is your favourite colour?">What is your favourite colour?</asp:ListItem>
                                              <asp:ListItem Value="What was the name of your childhood best friend?">What was the name of your childhood best friend?</asp:ListItem>
                                              <asp:ListItem Value="What is your mother's maiden name?">What is your mother's maiden name?</asp:ListItem>
                                        </asp:DropDownList>

                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                <%--        <input type="text" placeholder="Category" ID="email" class="form-control" name="name" required data-error="Please enter your email">--%>
                                        <asp:TextBox ID="answer1" runat="server" CssClass="form-control" Placeholder="Answer 1" RequiredDataError="Please enter a answer" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">

                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                              <asp:ListItem Value="What was the name of your first pet?">What was the name of your first pet?</asp:ListItem>
                                              <asp:ListItem Value="What is your favorite movie?">What is your favorite movie?</asp:ListItem>
                                              <asp:ListItem Value="What is the name of your first school?">What is the name of your first school?</asp:ListItem>
                                        </asp:DropDownList>

                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <div class="form-group">
                                <%--        <input type="text" placeholder="Category" ID="email" class="form-control" name="name" required data-error="Please enter your email">--%>
                                        <asp:TextBox ID="answer2" runat="server" CssClass="form-control" Placeholder="Answer 2" RequiredDataError="Please enter a answer" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>

                                </div>
                                <div class="col-md-15">
                                    <div class="form-group">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark btn-default btn-block" Text="Confirm" OnClick="Button1_Click" />
                                    </div>
                                    
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End Cart -->
</asp:Content>
