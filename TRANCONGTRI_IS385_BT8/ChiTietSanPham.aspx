<%@ Page Title="" Language="C#" MasterPageFile="~/OnlyHeader.Master" AutoEventWireup="true"
	CodeBehind="ChiTietSanPham.aspx.cs" Inherits="TRANCONGTRI_IS385_BT8.ChiTietSanPham" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<h3 class="main-title">Chi tiết sản phẩm</h3>
		
		<asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatLayout="Flow">
			<ItemTemplate>
				<div class="row product-detail-wrapper">
						<div class="product-detail-card">
						<div class="product-detail-container">
							<h3 class="product-detail-title">
								<asp:Label ID="Label1" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
							</h3>
							<img class="product-detail-img" src='<%#"./assets/images/" + Eval("hinh")%>'
								alt="Card image cap">
						</div>
					</div>
					<div class="card discount-card-wrapper">
						<div style="flex: 1;">
							<div class="product-detail-discount">
								<p>Duy nhất hôm nay, khuyến mãi cực khủng, chỉ duy nhất hôm nay, ngày mai khuyến mãi tiếp 
									<br/>
									<span onClick="return alert('Thấy khuyến mãi nên bấm vào chứ gì ?')">
										<strong>Xem chi tiết</strong>
									</span>
								</p>
							</div>
							<h5><strong>Mô tả</strong></h5>
							<p class="product-detail-description">
								<asp:Label ID="Label3" runat="server" Text='<%# Eval("mota") %>'></asp:Label>
							</p>
							<h5><strong>Màu sắc</strong></h5>
							<div class="product-detail-color">
								<div onClick="return alert('Thấy có màu nên bấm vào chứ gì ?')" class="product-detail-color-item black"></div>
								<div onClick="return alert('Thấy có màu nên bấm vào chứ gì ?')" class="product-detail-color-item sliver"></div>
								<div onClick="return alert('Thấy có màu nên bấm vào chứ gì ?')" class="product-detail-color-item gold"></div>
							</div>
							
						</div>
						<div class="product-detail-footer">
							<div class="product-detail-price-wrapper">
								<p class="product-detail-price">
									<asp:Label ID="Label2" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
								</p>
								<div class="product-detail-quantity">
									<asp:Label ID="cost" style="display: none;" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
									<asp:Button ID="Button1" class="quantity-btn" OnClick="Button1_Click" runat="server" Text="-"/>
									<asp:Label ID="quantity" class="quantity-label" runat="server" Text="1"></asp:Label>
									<asp:Button ID="Button2" class="quantity-btn" OnClick="Button2_Click" runat="server" Text="+" />
								</div>
							</div>
							<asp:LinkButton class="btn btn-primary buy-btn" ID="LinkButton1" runat="server"
								Text="Thêm vào giỏ hàng" CommandName="add" CommandArgument='<%# Eval("mahang") %>'>
							</asp:LinkButton>
						</div>
					</div>
				</div>
				</ItemTemplate>
			</asp:DataList>

	</asp:Content>