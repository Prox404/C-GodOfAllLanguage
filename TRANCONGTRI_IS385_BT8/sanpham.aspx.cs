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
    public partial class sanpham : System.Web.UI.Page
    {
        const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True;MultipleActiveResultSets=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            string q;
            if (Context.Items["ml"] == null)
                q = "select * from mathang";
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from mathang where maloai = '" + maloai + "'";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            Context.Items["mh"] = mahang;
            Server.Transfer("ChiTietSanPham.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string mahang = ((LinkButton)sender).CommandArgument;
            string tendangnhap = "";
            try
            {
                tendangnhap = Request.Cookies["TenDN"].Value;
            }
            catch (System.Exception)
            {
				Response.Redirect("dangnhap.aspx");
            }

            string sql = "select * from donhang where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
            SqlConnection con = new SqlConnection(connect);
            try
            {
               con.Open();
				SqlCommand cmd = new SqlCommand(sql, con);
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					int soluong = int.Parse(reader["soluong"].ToString());
					soluong++;
					sql = "update donhang set soluong = " + soluong + " where tendangnhap = '" + tendangnhap + "' and mahang = '" + mahang + "'";
					cmd = new SqlCommand(sql, con);
					cmd.ExecuteNonQuery();
				}
				else
				{
					sql = "insert into donhang values('" + tendangnhap + "','" + mahang + "',1)";
					cmd = new SqlCommand(sql, con);
					cmd.ExecuteNonQuery();
				}
				reader.Close();
            }
            catch (SqlException err)
            {
                Response.Write("<b>Error</b>" + err.Message + "<p/>");
            }
            finally
            {
                con.Close();
            }
        }

		protected void search_TextChanged(object sender, EventArgs e)
		{
			string q ;
			
			if (Context.Items["ml"] == null)
                q = "select * from mathang where tenhang like '%" + search.Text + "%'";
            else
            {
                string maloai = Context.Items["ml"].ToString();
                q = "select * from mathang where maloai = '" + maloai + "' and tenhang like '%" + search.Text + "%'";
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
    }

}