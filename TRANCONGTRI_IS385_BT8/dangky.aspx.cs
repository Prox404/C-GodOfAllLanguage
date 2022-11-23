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
    public partial class dangky : System.Web.UI.Page
    {

        const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True";
        private const string Path = "homepage.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
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
                    Response.Redirect(Path);
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
    }
}