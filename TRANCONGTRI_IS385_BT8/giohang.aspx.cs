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
    public partial class giohang : System.Web.UI.Page
    {

        const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            string tendangnhap = "";
            try
			{
				tendangnhap = Request.Cookies["TenDN"].Value;
			}
			catch (System.Exception)
			{
                Response.Redirect("homepage.aspx");
			}
			
            string sql = "select * from donhang, mathang where donhang.mahang = mathang.mahang and tendangnhap = '" + tendangnhap + "'";
			SqlConnection con = new SqlConnection(connect);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    this.DataList1.DataSource = dt;
                    this.DataList1.DataBind();
                }
                else
                {
                    this.Label1.Text = "Không có sản phẩm nào trong giỏ hàng";
                }
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

		protected void Button2_Click(object sender, EventArgs e)
		{
            string tendangnhap = Request.Cookies["TenDN"].Value;
            string mahang =  ((LinkButton)sender).CommandArgument;

            string sql = "select * from donhang where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
            SqlConnection con = new SqlConnection(connect);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int soluong = int.Parse(reader["soluong"].ToString());
                    reader.Close();
                    soluong++;
                    sql = "update donhang set soluong = " + soluong + " where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('Sản phẩm không tồn tại !');</script>");
                }
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

		protected void Button1_Click(object sender, EventArgs e)
		{
            string tendangnhap = Request.Cookies["TenDN"].Value;
            string mahang =  ((LinkButton)sender).CommandArgument;

            string sql = "select * from donhang where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
            SqlConnection con = new SqlConnection(connect);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int soluong = int.Parse(reader["soluong"].ToString());
                    reader.Close();
                    soluong--;
                    sql = "update donhang set soluong = " + soluong + " where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('Sản phẩm không tồn tại !');</script>");
                }
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

		protected void Button3_Click(object sender, EventArgs e)
		{
            string tendangnhap = Request.Cookies["TenDN"].Value;
            string mahang =  ((LinkButton)sender).CommandArgument;

            string sql = "delete from donhang where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
            SqlConnection con = new SqlConnection(connect);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
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