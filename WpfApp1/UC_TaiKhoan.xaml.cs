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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_TaiKhoan.xaml
    /// </summary>
    public partial class UC_TaiKhoan : UserControl
    {
        public UC_TaiKhoan()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectDB connectDB = new ConnectDB();
            string sql = "Select d.TenDangNhap,d.MatKhau,d.MaNV,n.TenNV from DangNhap d inner join NhanVien n on d.MaNV=n.MaNV";
            dg_TaiKhoan.ItemsSource = connectDB.getAllData(sql).DefaultView;
            txttaikhoan.Text = "";

        }
        public static bool check = false;
        private void btnThemTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            check = true;
            UC_ThemTaiKhoan uC_ThemTaiKhoan =new UC_ThemTaiKhoan();
            uC_ThemTaiKhoan.ShowDialog();
        }

        private void dg_TaiKhoan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_TaiKhoan.SelectedItem != null)
            {
                var firstColumn = dg_TaiKhoan.SelectedCells[0];
                var firstColumnValue = ((TextBlock)firstColumn.Column.GetCellContent(firstColumn.Item)).Text;
                txttaikhoan.Text = firstColumnValue;
               // MessageBox.Show(txttaikhoan.Text);
            }
        }
        
        private void btnSuaTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            check = false;
            UC_ThemTaiKhoan usC = new UC_ThemTaiKhoan();
            usC.txtTenDN.Text = txttaikhoan.Text;
            usC.ShowDialog();
           
        }

        private void btnXoaTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectDB.connectionString);
            try
            {
                
                SqlCommand cmd = new SqlCommand("proc_DeleteUserAccountByUserName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 200).Value = txttaikhoan.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa tài khoản thành công !");
                conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                    MessageBox.Show("Không có quyền admin");
                else
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
            }
           

        }
    }
}
