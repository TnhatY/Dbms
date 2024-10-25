using Do_an.config;
using Do_an.dao;
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
    /// Interaction logic for ThemNhanVien.xaml
    /// </summary>
    public partial class UC_ThemNhanVien : Window
    {
        SqlConnection connection = ConnectDB.getconnection();
        public UC_ThemNhanVien()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LoadComboBox()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaCV, TenCV FROM CongViec", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbmaCV.ItemsSource = dataTable.DefaultView;
                cbmaCV.DisplayMemberPath = "TenCV";
                cbmaCV.SelectedValuePath = "MaCV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btThemNV_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
            nhanVien_DAO.ThemNhanVien(txtMaNV.Text, txtHoNV.Text, txtTenNV.Text, txtDiaChi.Text, txtsdt.Text, txtgt.Text, dpNgaySinh.DisplayDate, cbmaCV.SelectedValue.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBox();
        }
    }
}
