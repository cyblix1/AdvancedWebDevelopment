<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_ForgetPassword.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_ForgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <!-- Start Contact Us  -->
    <div class="contact-box-main">
        <div class="container">
            <div class="row">
      
                <div class="col-lg-12 col-sm-12">
                    <div class="contact-form-right">
                        <h2>Security Questions</h2>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="lblquestion1" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtanswer1" runat="server" CssClass="form-control" Placeholder="Answer" RequiredDataError="Please enter a answer" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="lblquestion2" runat="server"></asp:Label>
                                        <asp:TextBox ID="txtanswer2" runat="server" CssClass="form-control" Placeholder="Answer" RequiredDataError="Please enter a answer" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>

 
                                <div class="col-md-12">
                              
                                    <div class="submit-button text-center">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn hvr-hover" Text="Submit" OnClick="btnSubmit_CLick"/>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn hvr-hover" Text="Cancel" OnClick="btnCancel_Click"/>
                                        <div class="clearfix"></div>
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
