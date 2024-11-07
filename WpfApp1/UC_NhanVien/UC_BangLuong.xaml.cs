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
    /// Interaction logic for UC_BangLuong.xaml
    /// </summary>
    public partial class UC_BangLuong : UserControl
    {
        public UC_BangLuong()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLuong_Click(object sender, RoutedEventArgs e)
        {
            
            int thang = int.Parse(cbThang.Text);
            int nam = int.Parse(cbNam.Text);
            NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();

            if(nhanVien_DAO.tinhLuongNV(nam, thang)!=null && nhanVien_DAO.tinhLuongNV(nam, thang).Rows.Count > 0)
            {
                dataGridBangLuong.ItemsSource = nhanVien_DAO.tinhLuongNV(nam, thang).DefaultView;
            }
            else {
                MessageBox.Show("Không có dữ liệu cho thời gian đã chọn!");
            }
            
        }
    }
}
