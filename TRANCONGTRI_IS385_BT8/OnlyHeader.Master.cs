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
    public partial class OnlyHeader : System.Web.UI.MasterPage
    {
		const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True";
		private const string Path = "sanpham.aspx";

		protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string tendangnhap = Request.Cookies["TenDN"].Value;
                this.Button1.Visible = false;
                this.Button2.Visible = false;
                this.Button3.Visible = true;
            }
            catch (System.Exception)
            {

                this.Button1.Visible = true;
                this.Button2.Visible = true;
                this.Button3.Visible = false;
            }
        }

        

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string ten = this.Login1.UserName;
            string matkhau = this.Login1.Password;
            string sql = "select * from khachhang where tendangnhap = '" + ten + "' and matkhau = '" + matkhau + "'";
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connect);
                da.Fill(table);
            }
            catch (SqlException err)
            {
                Response.Write("<b>Error</b>" + err.Message + "<p/>");
            }
            if (table.Rows.Count != 0)
            {
                Response.Cookies["TenDN"].Value = ten;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                this.Login1.FailureText = "Tên đăng nhập hay mật khẩu không đúng!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showLoginModal();", true);
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "Call register";
            string username = this.TextBox1.Text;
            string password = this.TextBox2.Text;

            string sql = "select * from khachhang where tendangnhap = '" + username + "'";
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
                    this.Label1.Text = "Tên đăng nhập đã tồn tại!";
                }
                else
                {
                    reader.Close();
                    string sql1 = "insert into khachhang(tendangnhap, matkhau) values('" + username + "', '" + password + "')";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();
                    Response.Cookies["TenDN"].Value = username;
                    this.Label1.Text = "Đăng ký thành công!";
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (SqlException err)
            {
                this.Label1.Text = err.Message;
            }
            finally
            {

                con.Close();
            }
        }

		protected void Button3_Click(object sender, EventArgs e)
		{
			Response.Cookies["TenDN"].Expires = DateTime.Now.AddDays(-1);
			Response.Redirect(Request.RawUrl);
		}
	}



}