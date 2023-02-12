<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_Cart.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- Start Cart  -->
    <div class="cart-box-main">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-main table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Images</th>
                                    <th>Product Name</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                    <th>Remove</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtId" runat="server" Visible="false" Text='<%# Eval("ProductId") %>'></asp:TextBox>
                                        <tr>
                                            <td class="thumbnail-img">
                                                <asp:ImageButton ID="Prod" CssClass="img-fluid" ImageUrl='<%# Eval("image") %>' runat="server" />
                                            </td>
                                            <td class="name-pr">
                                                <p class="lblprice" runat="server"> <%# Eval("ProductName") %> </p>
                                            </td>
                                            <td class="price-pr">
                                                <p class="lblprice" runat="server"><%# Eval("Price") %> </p>
                                            </td>
                                            <td class="quantity-box"><asp:TextBox ID="txtQuantity" CssClass="c-input-text qty text" runat="server" Text='<%# Eval("Quantity") %>' Width="40px" /></td>
                                            <td class="total-pr">
                                                 <p class="total" runat="server"><%# Eval("Total") %> </p>
                                            </td>
                                            <td class="remove-pr">
                                                <asp:LinkButton runat="server" OnClick="DeleteRow" CommandArgument='<%# Eval("ProductId") %>'>>
                                                    <i class="fas fa-times"></i>
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
      
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

            <%--coupon+submit--%>
            <div class="row my-5">
                <div class="col-lg-6 col-sm-6">
                    <div class="coupon-box">
                        <div class="input-group input-group-sm">
                            <input class="form-control" placeholder="Enter your coupon code" aria-label="Coupon code" type="text">
                            <div class="input-group-append">
                                <button class="btn btn-theme" type="button">Apply Coupon</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-sm-6">
                    <div class="update-box">
                        <asp:Button runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="UPDATE CART" />
                    </div>
                </div>
            </div>
            
            <%--total stuff--%> 
            <div class="row my-5">
                <div class="col-lg-8 col-sm-12"></div>
                <div class="col-lg-4 col-sm-12">
                    <div class="order-box">
                        <h3>Order summary</h3>
                        <div class="d-flex gr-total">
                            <h5>Grand Total</h5>
                           <%-- <h5 class="prodname" id="lblname" runat="server"> <%# Eval("name") %> </h5>--%>
                            <asp:Label runat="server" class="ml-auto h5" ID="lblGrandTotal" Text=""></asp:Label>
                        </div>
                        <hr> </div>
                </div>
                <div class="col-12 d-flex shopping-box"><a href="checkout.html" class="ml-auto btn hvr-hover">Checkout</a> </div>
            </div>

        </div>
    </div>
    <!-- End Cart -->


</asp:Content>
