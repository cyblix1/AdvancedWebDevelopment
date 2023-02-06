<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="Customer_Shop.aspx.cs" Inherits="AdvancedWebDevelopment.Customer_Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <!-- Start Shop Page  -->
     <!-- Start Shop Page  -->
    <div class="shop-box-inner">
        <div class="container">
            <div class="row">
                <div class="col-xl-3 col-lg-3 col-sm-12 col-xs-12 sidebar-shop-left">
                    <div class="product-categori">
                        <div class="search-product">
                            <form action="#">
                                <input class="form-control" placeholder="Search here..." type="text">
                                <button type="submit"> <i class="fa fa-search"></i> </button>
                            </form>
                        </div>
                        <div class="filter-sidebar-left nav nav-tabs">
                            <div class="title-left">
                                <h3>Categories</h3>
                            </div>
                            <div class="list-group list-group-collapse list-group-sm list-group-tree" id="list-group-men" data-children=".sub-men">
                                <div class="list-group-collapse sub-men">
                                    <a class="list-group-item list-group-item-action" href="#sub-men1" data-toggle="collapse" aria-expanded="true" aria-controls="sub-men1">Clothing <small class="text-muted">(100)</small>
								</a>
                                    <div class="collapse show" id="sub-men1" data-parent="#list-group-men">
                                        <div class="list-group">
                                            <a href="#repeater1" data-toggle="tab" class="">T-Shirts <small class="text-muted">(50)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">Polo T-Shirts <small class="text-muted">(10)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">Round Neck T-Shirts <small class="text-muted">(10)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">V Neck T-Shirts <small class="text-muted">(10)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">Hooded T-Shirts <small class="text-muted">(20)</small></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="list-group-collapse sub-men">
                                    <a class="list-group-item list-group-item-action" href="#sub-men2" data-toggle="collapse" aria-expanded="false" aria-controls="sub-men2">Footwear 
								<small class="text-muted">(50)</small>
								</a>
                                    <div class="collapse" id="sub-men2" data-parent="#list-group-men">
                                        <div class="list-group">
                                            <a href="#repeater2" data-toggle="tab" class="">Sports Shoes <small class="text-muted">(10)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">Sneakers <small class="text-muted">(20)</small></a>
                                            <a href="#" class="list-group-item list-group-item-action">Formal Shoes <small class="text-muted">(20)</small></a>
                                        </div>
                                    </div>
                                </div>
                                <a href="#" class="list-group-item list-group-item-action"> Men  <small class="text-muted">(150) </small></a>
                                <a href="#" class="list-group-item list-group-item-action">Accessories <small class="text-muted">(11)</small></a>
                                <a href="#" class="list-group-item list-group-item-action">Bags <small class="text-muted">(22)</small></a>
                            </div>
                        </div>
                        <div class="filter-price-left">
                            <div class="title-left">
                                <h3>Price</h3>
                            </div>
                            <div class="price-box-slider">
                                <div id="slider-range"></div>
                                <p>
                                    <input type="text" id="amount" readonly style="border:0; color:#fbb714; font-weight:bold;">
                                    <button class="btn hvr-hover" type="submit">Filter</button>
                                </p>
                            </div>
                        </div>
            

                    </div>
                </div>
                <div class="col-xl-9 col-lg-9 col-sm-12 col-xs-12 shop-content-right">
                    <div class="right-product-box">
                        <div class="product-item-filter row">
                            <div class="col-12 col-sm-8 text-center text-sm-left">
                                <div class="toolbar-sorter-right">
                                    <span>Sort by </span>
                                    <select id="basic" class="selectpicker show-tick form-control" data-placeholder="$ USD">
									<option data-display="Select">Nothing</option>
									<option value="1">Popularity</option>
									<option value="2">High Price → High Price</option>
									<option value="3">Low Price → High Price</option>
									<option value="4">Best Selling</option>
								</select>
                                </div>
                               
                            </div>
                            <div class="col-12 col-sm-4 text-center text-sm-right">
                                <ul class="nav nav-tabs ml-auto">
                                    <li>
                                        <a class="nav-link active" href="#repeater1" data-toggle="tab"> <i class="fa fa-th"></i> </a>
                                    </li>
                                    <li>
                                        <a class="nav-link" href="#repeater2" data-toggle="tab"> <i class="fa fa-list-ul"></i> </a>
                                    </li>
                                     <li>
                                        <a class="nav-link" href="#repeater3" data-toggle="tab"> <i class="fa fa-list-ul"></i> </a>
                                    </li>
                                </ul>
                            </div>
                        </div>


                        <div class="row product-categorie-box">
                            <div class="tab-content">
                                <%--Content 1 (for reapeater 1)--%>
                                <div role="tabpanel" class="tab-pane fade show active" id="repeater1">
                                    <div class="row">                    
                                        <%--start repeater 1--%>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                                        <div class="products-single fix">
                                                            <div class="box-img-hover">
                                                                <div class="type-lb">
                                                                    <p class="new">New</p>
                                                                </div>
                                                                <asp:ImageButton ID="Prod" CssClass="img" ImageUrl='<%# Eval("image") %>' runat="server" />
                                                                <%-- this replace above--%>
                                                                <%--<asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />--%>
                                                    <div class="mask-icon">
                                                        <ul>
                                                            <li><a href="#" onclick="window.location.href='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("Id")) %>'" data-toggle="tooltip" data-placement="right" title="View"><i class="fas fa-eye"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Compare"><i class="fas fa-sync-alt"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Add to Wishlist"><i class="far fa-heart"></i></a></li>
                                                        </ul>
                                                        <a class="cart" href="#">Add to Cart</a>
                                                    </div>
                                                </div>
                                                <div class="why-text">
                                                    <h4 class="prodname" id="lblname" runat="server"> <%# Eval("name") %> </h4>
                                                   <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>

                                                    <h5 class="prodprice" id="lblPrice" runat="server"> <%# Eval("price") %> </h5>
                                                    <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblPrice" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>                                               
                                                            </div>
                                                        </div>
                                                    </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--end repeater 1--%>
                                    </div>
                                </div>
                                <%--End Content 1 (for reapeater 1)--%>

                                  <%--Content 2 (for reapeater 2)--%>
                                <div role="tabpanel" class="tab-pane fade show active" id="repeater2">
                                    <div class="row">                    
                                        <%--start repeater 1--%>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                                        <div class="products-single fix">
                                                            <div class="box-img-hover">
                                                                <div class="type-lb">
                                                                    <p class="new">New</p>
                                                                </div>
                                                                <asp:ImageButton ID="Prod" CssClass="img" ImageUrl='<%#Eval("image") %>' runat="server" />
                                                                <%-- this replace above--%>
                                                                <%--<asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />--%>
                                                    <div class="mask-icon">
                                                        <ul>
                                                            <li><a href="#" onclick="window.location.href='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("Id")) %>'" data-toggle="tooltip" data-placement="right" title="View"><i class="fas fa-eye"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Compare"><i class="fas fa-sync-alt"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Add to Wishlist"><i class="far fa-heart"></i></a></li>
                                                        </ul>
                                                        <a class="cart" href="#">Add to Cart</a>
                                                    </div>
                                                </div>
                                                <div class="why-text">
                                                    <h4 class="prodname" id="lblname" runat="server"> <%# Eval("name") %> </h4>
                                                   <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>

                                                    <h5 class="prodprice" id="lblPrice" runat="server"> <%# Eval("price") %> </h5>
                                                    <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblPrice" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>                                               
                                                            </div>
                                                        </div>
                                                    </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--end repeater 2--%>
                                    </div>
                                </div>
                                <%--End Content 2 (for reapeater 2)--%>

                                    <%--Content 3 (for reapeater 2)--%>
                                <div role="tabpanel" class="tab-pane fade show active" id="repeater3">
                                    <div class="row">                    
                                        <%--start repeater 1--%>
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-6 col-md-6 col-lg-4 col-xl-4">
                                                        <div class="products-single fix">
                                                            <div class="box-img-hover">
                                                                <div class="type-lb">
                                                                    <p class="new">New</p>
                                                                </div>
                                                                <asp:ImageButton ID="Prod" CssClass="img" ImageUrl='<%#Eval("image") %>' runat="server" />
                                                                <%-- this replace above--%>
                                                                <%--<asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID"))%>' ID="imgBooks" CssClass="bookimage" ImageUrl='<%#Eval("BS_Image") %>' runat="server" />--%>
                                                    <div class="mask-icon">
                                                        <ul>
                                                            <li><a href="#" onclick="window.location.href='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("Id")) %>'" data-toggle="tooltip" data-placement="right" title="View"><i class="fas fa-eye"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Compare"><i class="fas fa-sync-alt"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Add to Wishlist"><i class="far fa-heart"></i></a></li>
                                                        </ul>
                                                        <a class="cart" href="#">Add to Cart</a>
                                                    </div>
                                                </div>
                                                <div class="why-text">
                                                    <h4 class="prodname" id="lblname" runat="server"> <%# Eval("name") %> </h4>
                                                   <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>

                                                    <h5 class="prodprice" id="lblPrice" runat="server"> <%# Eval("price") %> </h5>
                                                    <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblPrice" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>                                               
                                                            </div>
                                                        </div>
                                                    </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--end repeater 3--%>
                                    </div>
                                </div>
                                <%--End Content 3 (for reapeater 3)--%>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
ipt>
    <!-- End Shop Page -->
</asp:Content>
