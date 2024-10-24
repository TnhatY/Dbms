﻿using Do_an;

using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
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
using System.Data.SqlClient;
using Do_an.config;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for F_Main.xaml
    /// </summary>
    public partial class F_Main : Window
    {
       
        public F_Main()
        {
            InitializeComponent();
            DataContext = this;
            
           
        }
        
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
           
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(2,0,0,2);
            btnGioHang.BorderThickness = new Thickness(0); 
            btnTrangChu.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnGioHang.Background = null;
            btnDaMua.Background = null;
            btnBanHang.Background = null;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/trangchu1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            UC_MuaSam uC_MuaSam = new UC_MuaSam();
            user.Content = uC_MuaSam;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            texttimkiem = null;
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //thanhmenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //thanhmenu.IsChecked = true;
            
           
        }


        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDaMua_Click(object sender, RoutedEventArgs e)  
        {
           
            UC_DaMua uC_DaMua = new UC_DaMua();
            user.Content = uC_DaMua;
            btnDaMua.BorderThickness = new Thickness(2,0,0,2);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnBanHang.BorderThickness = new Thickness(0);
            
            btnBanHang.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnDaMua.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/spdamua.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        public void btnGioHang_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;

            UC_DaMua uC_GioHang = new UC_DaMua();
            uC_GioHang.tittle.Text = "Sản phẩm đã thêm vào giỏ";
            user.Content = uC_GioHang;
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(2, 0, 0, 2);
            btnBanHang.BorderThickness = new Thickness(0);
           

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/giohang1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnGioHang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnBanHang.Background= null;
            btnCaiDat.Background = null;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }

        private void btnBanHang_Click(object sender, RoutedEventArgs e)
        {
            //thanhmenu.IsChecked = true;
          

            btnBanHang.BorderThickness= new Thickness(2,0,0,2);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            // btnThongKe.BorderThickness = new Thickness(0);
            
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/banhang.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnBanHang.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background= null;
            btnCaiDat.Background = null;
            UC_DaMua uC_BanHang = new UC_DaMua();
            uC_BanHang.tittle.Text = "Sản phẩm đang bán";
            user.Content = uC_BanHang;
            btnCaiDat.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
        }
        private void Them_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVoucher_Click(object sender, RoutedEventArgs e)
        {
           
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnCaiDat.BorderThickness = new Thickness(2,0,0,2);
            btnBanHang.Background = null;
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnCaiDat.Background=new SolidColorBrush(Color.FromRgb(136, 0, 204)); 
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
        }
        public static string texttimkiem = "";
        public static string menu1 = "";
        private void timkiem_Click(object sender, RoutedEventArgs e)
        {
            timkiem1.Text = null;
            texttimkiem = txttimkiem.Text;
           
            UC_MuaSam uc = new UC_MuaSam();
            user.Content = uc;
        }

        private void btnYeuThich_Click(object sender, RoutedEventArgs e)
        {
           
            UC_gioHang uc = new UC_gioHang();
            user.Content = uc;
            btnBanHang.BorderThickness = new Thickness(0);
            btnDaMua.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnGioHang.BorderThickness = new Thickness(0);
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/yeuthichtile.png", UriKind.RelativeOrAbsolute); 
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnBanHang.Background = null;
            btnDaMua.Background = null;
            btnTrangChu.Background = null;
            btnGioHang.Background = null;
            btnCaiDat.Background = null;
            btnyeuthich.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnyeuthich.BorderThickness = new Thickness(2, 0, 0, 2);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Collapsed;
            logo.Visibility = Visibility.Collapsed;
            content.Margin = new Thickness(15, 100, 0, 10);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Visible;
            logo.Visibility = Visibility.Visible;
            content.Margin = new Thickness(170, 100, 0, 10);
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            ThemSP_Window themSP_Window = new ThemSP_Window();
            themSP_Window.chinhsua.Visibility = Visibility.Collapsed;
            themSP_Window.Show();
        }

        private void btnNguoiBan_Click(object sender, RoutedEventArgs e)
        {
            UC_QL_NguoiBan uC_QL_NguoiBan=new UC_QL_NguoiBan();
            user.Content = uC_QL_NguoiBan;
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nguoiban.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnyeuthich.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNhanvien.BorderThickness = new Thickness(2, 0, 0, 2);
        }

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            UC_background uC_Background=new UC_background();
            user.Content = uC_Background;
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nguoimua.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNguoiMua.BorderThickness = new Thickness(2, 0, 0, 2);
        }

        private void btnNguoiMua_Click(object sender, RoutedEventArgs e)
        {
            UC_KhachHang uC_Background = new UC_KhachHang();
            user.Content = uC_Background;
            menu1 = "khachhang";
            btnCaiDat.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nguoimua.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnCaiDat.Background = null;
            btnyeuthich.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNguoiMua.BorderThickness = new Thickness(2, 0, 0, 2);
        }
    }
}
