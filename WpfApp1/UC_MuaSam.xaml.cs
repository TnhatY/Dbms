using Do_an;
using Do_an.dao;
using Do_an.model;
using System;
using System.Collections.Generic;
using System.Data;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_MuaSam.xaml
    /// </summary>
    public partial class UC_MuaSam : UserControl
    {
        
      

        public UC_MuaSam()
        {
            InitializeComponent();
            DataContext = this;
        }

       
        private void DanhMuc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SanPham_DAO sanPham_DAO = new SanPham_DAO();
                if (sender == SpDienThoai)
                {
                    SpDienThoai.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Điện thoại");
                }
                else if (sender == SpDoDienTu)
                {
                    SpDoDienTu.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Đồ điện tử");
                }
                else if (sender == SpDoDung)
                {
                    SpDoDung.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpXeMay.Background = Spthethao.Background = Spthoitrang.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Đồ gia dụng");
                }
                else if (sender == Spthethao)
                {
                    Spthethao.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthoitrang.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Thể thao");
                }
                else if (sender == Spthoitrang)
                {
                    Spthoitrang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background = SpXeMay.Background = Spthethao.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Thời trang");
                }
                else if (sender == SpXeMay)
                {
                    SpXeMay.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
                    SpDienThoai.Background = SpDoDienTu.Background = SpDoDung.Background = Spthethao.Background = Spthoitrang.Background = null;
                    controlsanpham.ItemsSource = sanPham_DAO.timkiemSP("Xe cộ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            if(F_Main.texttimkiem == null)
            {
                    List<SanPham> sp = sanPham_DAO.listSP();
                controlsanpham.ItemsSource = sp;
            }
            else
            {
                List<SanPham> sp = sanPham_DAO.timkiemSP(F_Main.texttimkiem);
                controlsanpham.ItemsSource = sp;
            }
            
        }
    }
}
