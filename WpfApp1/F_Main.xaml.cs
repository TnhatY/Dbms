using Do_an;

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

using System.Data.SqlClient;
using Do_an.config;
using Do_an.dao;
using System.Drawing;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using System.Windows.Media.Imaging;

namespace Do_an
{

    public partial class F_Main : Window
    {
        public static F_Main instance = new F_Main();
       
        public F_Main()
        {
            InitializeComponent();
            DataContext = this;
            instance = this;
           
        }
        public static string texttimkiem = "";
        public static string thanhmenu1 = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            thanhmenu1 = "trangchu";
        
            btnTrangChu.BorderThickness = new Thickness(2,0,0,2);
          
            btnTrangChu.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
          
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/trangchu1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            UC_MuaSam uC_MuaSam = new UC_MuaSam();
            user.Content = uC_MuaSam;
            btnTinhLuong.Background = null;
            btnTinhLuong.BorderThickness = new Thickness(0);
            texttimkiem = null;
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnHoaDon.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }
        public static bool checkThemSp = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkThemSp = false;
            btnTrangChu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }


        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     
     
        private void Them_Click(object sender, EventArgs e)
        {
           
        }

       
        private void timkiem_Click(object sender, RoutedEventArgs e)
        {
            timkiem1.Text = null;
            texttimkiem = txttimkiem.Text;
            if(thanhmenu1=="trangchu")
            {
                UC_MuaSam uc = new UC_MuaSam();
                user.Content = uc;
            }else if (thanhmenu1 == "nhanvien")
            {
                
            }else if (thanhmenu1 == "hoadon")
            {
                UC_HoaDon uc = new UC_HoaDon();
                user.Content = uc;
            }
           
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
            checkThemSp = true;
            ThemSP_Window themSP_Window = new ThemSP_Window();
            themSP_Window.btnchinhsua.Visibility = Visibility.Collapsed;
            themSP_Window.Show();
        }

      

        private void btnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            thanhmenu1 = "nhanvien";
            UC_NhanVien uC_NhanVien = new UC_NhanVien();
            user.Content = uC_NhanVien;
            btnTinhLuong.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/nhanvien.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);
            btnTinhLuong.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnHoaDon.Background = null;
            btnTrangChu.Background = null;
            btnTrangChu.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNhanvien.BorderThickness = new Thickness(2, 0, 0, 2);
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }

        private void btnNguoiMua_Click(object sender, RoutedEventArgs e)
        {
            UC_KhachHang uC_Background = new UC_KhachHang();
            user.Content = uC_Background;
            thanhmenu1 = "khachhang";
            btnTinhLuong.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/khachhang.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);

            btnTinhLuong.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnNguoiMua.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(136, 0, 204));
            btnNguoiMua.BorderThickness = new Thickness(2, 0, 0, 2);
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }

		private void btnThongKe_Click(object sender, RoutedEventArgs e)
		{
			UC_Thongke uC_Background = new UC_Thongke();
			user.Content = uC_Background;
            btnThongKe.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnThongKe.BorderThickness = new Thickness(2, 0, 0, 2);
            btnHoaDon.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnTinhLuong.BorderThickness = new Thickness(0);
            btnTrangChu.Background = null;
            btnTinhLuong.Background = null;
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/thongke1.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            thanhmenu1 = "hoadon";
            UC_HoaDon uC_HoaDon = new UC_HoaDon();
            user.Content = uC_HoaDon;
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnTinhLuong.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/hoadon.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnTrangChu.Background = null;
            btnTinhLuong.Background = null;
            btnHoaDon.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnHoaDon.BorderThickness = new Thickness(2, 0, 0, 2);
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }

        private void btnTinhLuong_Click(object sender, RoutedEventArgs e)
        {
            UC_BangLuong uC_BangLuong = new UC_BangLuong();
            user.Content = uC_BangLuong;
            btnHoaDon.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnTinhLuong.BorderThickness = new Thickness(2, 0, 0, 2);
            btnTrangChu.Background = null;
            btnTinhLuong.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/tinhluong.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);
            btnTaiKhoan.Background = null;
            btnTaiKhoan.BorderThickness = new Thickness(0);
        }

        private void btnTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            UC_TaiKhoan uC_TaiKhoan = new UC_TaiKhoan();
            user.Content = uC_TaiKhoan;
            btnHoaDon.Background = null;
            btnHoaDon.BorderThickness = new Thickness(0);
            btnTrangChu.BorderThickness = new Thickness(0);
            btnTinhLuong.BorderThickness = new Thickness(0);
            btnTrangChu.Background = null;
            btnTinhLuong.Background = null;
            btnNguoiMua.Background = null;
            btnNguoiMua.BorderThickness = new Thickness(0);
            btnNhanvien.Background = null;
            btnNhanvien.BorderThickness = new Thickness(0);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/image/taikhoan.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            imageTittle.Source = bitmap;
            btnThongKe.Background = null;
            btnThongKe.BorderThickness = new Thickness(0);
            btnTaiKhoan.Background = new SolidColorBrush(Color.FromRgb(136, 0, 204));
            btnTaiKhoan.BorderThickness=new Thickness(2, 0, 0, 2);
        }
    }
}
