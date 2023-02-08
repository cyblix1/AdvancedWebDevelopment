<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_ForgetPasswordEmailInput.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_ForgetPasswordEmailInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <!-- Start Contact Us  -->
    <div class="contact-box-main">
        <div class="container">
            <div class="row">
      
                <div class="col-lg-12 col-sm-12">
                    <div class="contact-form-right">
                        <h2>Enter Email</h2>
                            <div class="row">

                                <div class="col-md-7">
                                    <div class="form-group">
                                        <%--<input type="text" class="form-control" id="subject" name="name" placeholder="Price" required data-error="Please enter your Subject">--%>
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" Placeholder="Email" RequiredDataError="Please enter your email" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                       
                                    <div class="submit-button text-left">
                                        <asp:Button ID="btnNext" runat="server" CssClass="btn hvr-hover" Text="Next" OnClick="btnNext_Click"/>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
