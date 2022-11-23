using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TRANCONGTRI_IS385_BT8
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["mh"] == null)
                q = "select * from mathang";
            else
            {
                string mahang = Context.Items["mh"].ToString();
                q = "select * from mathang where mahang = '" + mahang + "'";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(q, connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.DataList1.DataSource = dt;
                this.DataList1.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label quantity_label = (Label)this.DataList1.Items[0].FindControl("quantity");
            Label cost_label = (Label)this.DataList1.Items[0].FindControl("Label2");
            Label stock_cost = (Label)this.DataList1.Items[0].FindControl("cost");
            double quantity = Double.Parse(quantity_label.Text);
            double cost = Double.Parse(cost_label.Text);
            double stock_cost_value = Double.Parse(stock_cost.Text);

            if (quantity == 0)
            {
                Response.Write("<script>alert('Sản phẩm đã hết hàng')</script>");
            }
            else
            {
                cost_label.Text = (cost - stock_cost_value).ToString();
                quantity_label.Text = (quantity - 1).ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label quantity_label = (Label)this.DataList1.Items[0].FindControl("quantity");
            Label cost_label = (Label)this.DataList1.Items[0].FindControl("Label2");
            Label stock_cost = (Label)this.DataList1.Items[0].FindControl("cost");
            double quantity = Double.Parse(quantity_label.Text);
            double cost = Double.Parse(cost_label.Text);
            double stock_cost_value = Double.Parse(stock_cost.Text);

            cost_label.Text = (cost + stock_cost_value).ToString();
            quantity_label.Text = (quantity + 1).ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string tendangnhap = Request.Cookies["TenDN"].Value;
            string mahang = ((LinkButton)sender).CommandArgument;
            Label soluong_label = (Label)this.DataList1.Items[0].FindControl("quantity");
			string soluong = soluong_label.Text;

            string sql = "SELECT * FROM donhang WHERE tendangnhap = '" + tendangnhap + "' AND mahang = '" + mahang + "'";
			
			SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
					string soluong_cu = dr["soluong"].ToString();
					int soluong_moi = Int32.Parse(soluong_cu) + Int32.Parse(soluong);
                    string sql_update = "UPDATE donhang SET soluong = '" + soluong_moi + "' WHERE tendangnhap = '" + tendangnhap + "' AND mahang = '" + mahang + "'";
					SqlCommand cmd_update = new SqlCommand(sql_update, con);
                    cmd_update.ExecuteNonQuery();
                }
                else
                {
                    string sql_insert = "INSERT INTO donhang VALUES ('" + tendangnhap + "', '" + mahang + "', '" + soluong + "')";
                    SqlCommand cmd_insert = new SqlCommand(sql_insert, con);
                    cmd_insert.ExecuteNonQuery();
                }

                dr.Close();
				
				Response.Redirect("giohang.aspx");
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}