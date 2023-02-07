<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin_Shop.aspx.cs" Inherits="AdvancedWebDevelopment.Admin_Shop" %>
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
                    
                                <asp:TextBox ID="txtSearch" placeholder="Search here...." runat="server" CssClass="form-control"></asp:TextBox>    
                                <asp:Button ID="buttonSearch" runat="server" Text="Search" CssClass="form-control" OnClick="btnSearch_Click" />
                            <br />

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
                                        <asp:Button 
                                            ID="btnAddItem"
                                            Style="font-size: 14px; padding: 8px; margin-bottom: 10px; margin-right: 10px; border: 0.5px solid" 
                                            runat="server" 
                                            Text="INSERT" OnClick="btnAddItem_Click" />

                                    </li>
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
                                                            <%--<li><a href="#" onclick="window.location.href='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("Id")) %>'" data-toggle="tooltip" data-placement="right" title="View"><i class="fas fa-eye"></i></a></li>--%>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="View"><i class="fas fa-eye"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Compare"><i class="fas fa-sync-alt"></i></a></li>
                                                            <li><a href="#" data-toggle="tooltip" data-placement="right" title="Add to Wishlist"><i class="far fa-heart"></i></a></li>  
                                                        </ul>
                                                        <a class="cart" href="#">Add to Cart</a>
                                                    </div>
                                                </div>
                                                <div class="why-text">
                                                    <asp:Label ID="prodID" runat="server" Text='<%#Eval("Id")%>' Visible="False"></asp:Label>
                                                    <h4 class="prodname" id="lblname" runat="server"> <%# Eval("name") %> </h4>
                                                    <asp:TextBox ID="txtimg" runat="server" Visible="false" Text='<%# Eval("image") %>'></asp:TextBox>
                                                    <asp:TextBox ID="txtname" runat="server" Visible="false" Text='<%# Eval("name") %>'></asp:TextBox>
                                                    <asp:TextBox ID="txtdesc" runat="server" Visible="false" Text='<%# Eval("description") %>'></asp:TextBox>
                                                   <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblTitle" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>

                                                    <h5 class="prodprice" id="lblPrice" runat="server"> <%# Eval("price") %> </h5>
                                                    <asp:TextBox ID="txtprice" runat="server" Visible="false" Text='<%# Eval("price") %>'></asp:TextBox>
                                                    <%-- this replace above--%>
                                                   <%--<asp:Label CssClass="booktitle" ID="lblPrice" runat="server" Text='<%#Eval("BS_Title")%>'></asp:Label>--%>     
                                                    <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server" OnClick="OnEdit" Font-Size="X-Small" />
                                                    <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Onclick="OnUpdate" Visible="false" Font-Size="X-Small" />
                                                    <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" OnClick="OnCancel" Visible="false" Font-Size="X-Small" />
                                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Are you sure you want to delete this?');" Font-Size="X-Small" />


                                                </div>
                                            </div>
                                        </div>
                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--end repeater 1--%>
                                    </div>
                                </div>
                                <%--End Content 1 (for reapeater 1)--%>

                                  

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    <!-- End Shop Page -->
</asp:Content>
