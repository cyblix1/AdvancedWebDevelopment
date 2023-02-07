<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_AddProduct.aspx.cs" Inherits="AdvancedWebDevelopment.Admin_AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Start Contact Us  -->
    <div class="contact-box-main">
        <div class="container">
            <div class="row">
      
                <div class="col-lg-12 col-sm-12">
                    <div class="contact-form-right">
                        <h2>Add Product</h2>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
            <%--                            <input type="text" class="form-control" id="name" name="name" placeholder="Product Name" required data-error="Please enter product name">--%>
                                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" Placeholder="Product Name" RequiredDataError="Please enter product name" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                <%--        <input type="text" placeholder="Category" ID="email" class="form-control" name="name" required data-error="Please enter your email">--%>
                                        <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control" Placeholder="Category" RequiredDataError="Please enter a category" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <%--<input type="text" class="form-control" id="subject" name="name" placeholder="Price" required data-error="Please enter your Subject">--%>
                                        <asp:TextBox ID="txtprice" runat="server" CssClass="form-control" Placeholder="Price" RequiredDataError="Please enter a price" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label CssClass="labels" ID="Label5" runat="server" Text="Product Image:"></asp:Label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                               
                                        <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" CssClass="form-control" Placeholder="Description" Rows="4" RequiredDataError="Enter description" />
                                        <div class="help-block with-errors"></div>
                                    </div>
                                    <div class="submit-button text-center">
                                        <asp:Button ID="btnInsertProduct" runat="server" CssClass="btn hvr-hover" Text="Add" OnClick="btnInsertProduct_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn hvr-hover" Text="Cancel" OnClick="btnCancel_Click" />
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
