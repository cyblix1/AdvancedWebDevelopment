<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_EmailVerfication.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_EmailVerfication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <!-- Start Contact Us  -->
    <div class="contact-box-main">
        <div class="container">
            <div class="row">
      
                <div class="col-lg-12 col-sm-12">
                    <div class="contact-form-right">
                        <h2>Email Verification</h2>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
            <%--                            <input type="text" class="form-control" id="name" name="name" placeholder="Product Name" required data-error="Please enter product name">--%>
                                        <asp:TextBox ID="txtOTP" runat="server" CssClass="form-control" Placeholder="OTP" RequiredDataError="Enter valid OTP" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                     
                         

                                <div class="col-md-12">
                                  
                                    <div class="submit-button text-left">
                                        <asp:Button ID="btnsubmitotp" runat="server" CssClass="btn hvr-hover" Text="Verify" OnClick="btnsubmitotp_Click"  />
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
