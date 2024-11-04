using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_ThemTaiKhoan.xaml
    /// </summary>
    public partial class UC_ThemTaiKhoan : Window
    {
        public UC_ThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (UC_TaiKhoan.check)
            {
                btncapnhat.Visibility = Visibility.Collapsed;
                btnthem.Visibility = Visibility.Visible;
            }
            else
            {
                btnthem.Visibility= Visibility.Collapsed;
                btncapnhat.Visibility= Visibility.Visible;
                ConnectDB connectDB = new ConnectDB();
                DataTable dataTable = new DataTable();
                dataTable = connectDB.getAllData($"SELECT * FROM DangNhap WHERE TenDangNhap = '{txtTenDN.Text}'");
                try
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        txtMaNV.Text = row["MaNV"].ToString();
                        txtTenDN.Text = row["TenDangNhap"].ToString();
                        txtMatKhau.Text = row["MatKhau"].ToString();
                        txtMatKhau2.Text = row["MatKhau"].ToString();
                    }
                }catch(SqlException ex)
                {
                    if (ex.Number == 229)
                    {
                        MessageBox.Show("Bạn không có quyền Admin");
                    }else
                        MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectDB.connectionString);
            try
            {
                string sqlQuery = "proc_CreateAccount";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = txtTenDN.Text;
                cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 100).Value = txtMatKhau.Text;
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = txtMaNV.Text;
                if(txtMatKhau.Text!=txtMatKhau2.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp");
                    return;
                }
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Tạo tài khoản cho nhân viên thành công");
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại");
                }
                conn.Close();
                Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Không có quyền admin!");
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                conn.Close();
            }

        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectDB.connectionString);
            try
            {
                string sqlQuery = "proc_UpdateAccount";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = txtTenDN.Text;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = txtMatKhau.Text;
                cmd.Parameters.Add("@MaNV", SqlDbType.VarChar, 10).Value = txtMaNV.Text;
                if (txtMatKhau.Text != txtMatKhau2.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp");
                    return;
                }
                conn.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại");
                }
                conn.Close();
                Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Không có quyền admin!");
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                conn.Close();
            }

        }
    }
}
