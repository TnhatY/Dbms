using Do_an.dao;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for UC_ThemKhachHang.xaml
    /// </summary>
    public partial class UC_ThemKhachHang : Window
    {
        public UC_ThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            KhachHang_DAO khachHang_DAO = new KhachHang_DAO();

            khachHang_DAO.ThemKhachHang(txtMaKH.Text,txtTenKH.Text,txtDiaChi.Text,txtSDT.Text);
        }
    }
}
