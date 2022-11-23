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
	public partial class dangnhap : System.Web.UI.Page
	{

		const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hoang Luu\source\repos\TRANCONGTRI_IS385_BT8\TRANCONGTRI_IS385_BT8\App_Data\banhang.mdf;Integrated Security=True";
        private const string Path = "homepage.aspx";
		protected void Page_Load(object sender, EventArgs e)
		{

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
                Response.Redirect(Path);  
            }
            else {
                this.Login1.FailureText = "Tên đăng nhập hay mật khẩu không đúng!";
            }
        }
	}
}