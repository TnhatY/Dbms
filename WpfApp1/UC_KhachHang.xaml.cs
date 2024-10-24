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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_KhachHang.xaml
    /// </summary>
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
        }
        public DataTable XemDanhMucKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DanhMucKhachHang", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dg_khachhang.ItemsSource = XemDanhMucKhachHang().DefaultView;
        }

        private void btnTimkiem_Click(object sender, RoutedEventArgs e)
        {
            KhachHang_DAO khachHang_DAO = new KhachHang_DAO();
            dg_khachhang.ItemsSource = khachHang_DAO.KhachHang_SDT(txtsdt.Text).DefaultView;
        }
        private void dg_khachhang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_khachhang.SelectedItem != null)
            {
                var firstColumn = dg_khachhang.SelectedCells[0];
                var firstColumnValue = ((TextBlock)firstColumn.Column.GetCellContent(firstColumn.Item)).Text;
                makh.Text= firstColumnValue;
            }
        }

        private void btnThemkhachhang_Click(object sender, RoutedEventArgs e)
        {
            UC_ThemKhachHang uC_ThemKhachHang  = new UC_ThemKhachHang();
            uC_ThemKhachHang.ShowDialog();
        }
    }
}
