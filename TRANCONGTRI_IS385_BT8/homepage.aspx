<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeFile="homepage.aspx.cs"
	Inherits="TRANCONGTRI_IS385_BT8.homepage" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<div class="col-6 mb-4 search-wrapper">
			<asp:TextBox CssClass="form-control me-2" AutoCompleteType="Disabled" ID="search" runat="server"></asp:TextBox>
			<asp:LinkButton CssClass="btn btn-primary" OnClick="search_TextChanged" ID="Button1" runat="server" Text="Button" >
				<i class="fa-solid fa-magnifying-glass"></i>
			</asp:LinkButton>
		</div>

		<asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
			<ItemTemplate>
				<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("mahang") %>'
					OnClick="LinkButton1_Click">
					<div class="card product-card" style="width: 15rem;">
						<img class="card-img-top product-img" src='<%#"./assets/images/" + Eval("hinh")%>'
							alt="Card image cap">
						<div class="card-body">
							<h5 class="card-title">
								<asp:Label ID="Label1" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
							</h5>
							<p class="card-text">
								<asp:Label ID="Label2" runat="server" Text='<%# Eval("mota") %>'></asp:Label>
							</p>
							<asp:LinkButton class="btn btn-primary buy-btn" ID="LinkButton2" runat="server"
								Text="Thêm vào giỏ hàng" CommandName="add" CommandArgument='<%# Eval("mahang") %>'
								OnClick="LinkButton2_Click">
							</asp:LinkButton>
						</div>
					</div>
				</asp:LinkButton>
			</ItemTemplate>
		</asp:DataList>
	</asp:Content>