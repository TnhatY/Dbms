
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Do_an
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = passwordBox.Password;
            SqlConnection conn = ConnectDB.getconnection(); // Đảm bảo dùng cùng một đối tượng kết nối
            SqlCommand cmd = new SqlCommand("SELECT dbo.checkLogin(@user, @pass)", conn);
            cmd.Parameters.AddWithValue("@user", txtDangNhap.Text);
            cmd.Parameters.AddWithValue("@pass", passwordTextBox.Text);

            try
            {
                conn.Open();
                // Kiểm tra nếu `ExecuteScalar` trả về `null` và chuyển đổi sang kiểu `bool`
                object result = cmd.ExecuteScalar();
                bool count = result != null && (bool)result;
                F_Main f_Main = new F_Main();
                if (count)
                {
                    ConnectDB.username = txtDangNhap.Text;
                    ConnectDB.password = passwordTextBox.Text;
                    SqlCommand cmd1 = new SqlCommand($"select cv.TenCV from NhanVien nv inner join CongViec cv on cv.MaCV=nv.MaCV inner join DangNhap dn on dn.MaNV=nv.MaNV where dn.TenDangNhap='{txtDangNhap.Text}' and dn.MatKhau='{passwordTextBox.Text}'", conn);
                                       
                    object result2 = cmd1.ExecuteScalar();

                    if (result2 != null)
                    {
                        f_Main.tentk.Text = result2.ToString().Trim();
                    }
                    f_Main.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }


        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = passwordBox.Password;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/eye.png", UriKind.Relative));
            
        }
        
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTextBox.Text;
            passwordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/uneye.png", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
