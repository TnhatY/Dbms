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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_background.xaml
    /// </summary>
    public partial class UC_background : UserControl
    {
        public UC_background()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (F_Main.menu1 == "khachhang")
            {
                NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
                listNhanVien.ItemsSource = nhanVien_DAO.listNhanvien();
            }
            else
            {
                NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
                listNhanVien.ItemsSource = nhanVien_DAO.listNhanvien();
            }
            
        }

        private void themnhanvien_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
