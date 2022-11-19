<%@ Page Title="" Language="C#" MasterPageFile="~/OnlyHeader.Master" AutoEventWireup="true" CodeBehind="giohang.aspx.cs"
	Inherits="TRANCONGTRI_IS385_BT8.giohang" %>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div>
			<h3 class="main-title">Giỏ hàng</h3>

			<div id="cart-content" class="row">
				<div class="col-8">
					<asp:DataList ID="DataList1" runat="server" RepeatColumns="1" RepeatLayout="Flow">
						<ItemTemplate>
							<div class="product-item-card">
								<img class="card-img-top product-item-img" src='<%#"./assets/images/" + Eval("hinh")%>'
									alt="Card image cap">
								<div class="card-body">
									<h5 class="card-title product-item-name">
										<asp:Label ID="Label1" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
									</h5>
									<p class="card-text product-item-description">
										<i class="fa-solid fa-info"></i>
										<asp:Label ID="Label2" runat="server" Text='<%# Eval("mota") %>'></asp:Label>
									</p>
									<p class="card-text price-text">
										<i class="fa-solid fa-dollar-sign"></i>
										<asp:Label ID="Label3" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
									</p>

								</div>
								<div class="product-item-footer">
									<div class="product-detail-quantity">
										<asp:Button ID="Button1" class="quantity-btn" OnClick="Button1_Click"
											runat="server" Text="-" />
										<asp:Label class="quantity-label" ID="Label4" runat="server"
											Text='<%# Eval("soluong") %>'></asp:Label>
										<asp:Button ID="Button2" class="quantity-btn" OnClick="Button2_Click"
											runat="server" Text="+" />
									</div>
									<asp:Label ID="total" class="product-detail-price" runat="server"
										Text='<%# (Convert.ToInt32(Eval("soluong")) * Convert.ToInt32(Eval("dongia"))) %>'>
									</asp:Label>
									<asp:LinkButton ID="Button3" class="product-item-delete-btn" OnClick="Button3_Click"
										runat="server">
										<span class="fa-regular fa-trash-can"></span>
									</asp:LinkButton>
								</div>
							</div>
						</ItemTemplate>
					</asp:DataList>
				</div>
				<div class="col-4">
					<div class="product-item-discount  p-4">
						<div class="product-item-discount-header">
							<h5 class="product-item-discount-title">
								<strong>
									<i class="fa-regular fa-money-bill-1"></i>
									Giảm giá
								</strong>
							</h5>
							<div class="product-item-discount-input-wrapper">
								<img src="./assets/images/discount.png" alt="discount"
									class="product-item-discount-img">
								<input type="text" class="product-item-discount-input" placeholder="Nhập mã giảm giá">
									<p class="redeem-text" onclick="return alert('Thấy có mã giảm giá nên bấm thử chứ gì ?')">Đổi</p>
								</input>
							</div>
						</div>
					</div>

					<div class="product-item-discount  p-4 mt-4">
						<div class="product-item-discount-header">
							<h5 class="product-item-discount-title">
								<strong>
									<i class="fa-regular fa-file-lines"></i>
									Tóm tắt đơn hàng
								</strong>
							</h5>
							<div class="d-flex flex-row justify-content-between mb-2 align-center">
								<h5 class="mb-0">Tạm tính</h5>
								<p class="price-text mb-0" id="base-total"></p>
							</div>
							<div class="d-flex flex-row justify-content-between mb-2 align-center">
								<h5 class="mb-0">Khuyến mãi</h5>
								<p class="price-text mb-0" > 0</p>
							</div>
							<div class="d-flex flex-row justify-content-between mb-2 align-center">
								<h5 class="mb-0">Tổng cộng</h5>
								<p class="price-text mb-0" id="total"> 0</p>
							</div>
						</div>
						<Button onClick="return alert('Tưởng đặt được nên bấm vào chứ gì ?')"
							class="btn btn-primary buy-btn">
							Đặt hàng
						</Button>
					</div>
				</div>
			</div>

			<asp:Label runat="server" ID="Label1" Text=""></asp:Label>
		</div>

		<script type="text/javascript">
			document.getElementById("base-total");
			document.getElementById("total");
			document.getElementById("cart-content");

			let prices = document.getElementsByClassName("product-detail-price");
			let total = 0;
			for (let i = 0; i < prices.length; i++) {
				total += parseInt(prices[i].innerHTML);
			}
			document.getElementById("total").innerHTML = total;
			document.getElementById("base-total").innerHTML = total;

			if (prices.length == 0) {
				document.getElementById("cart-content").style.display = "none";
			}
		</script>
	</asp:Content>