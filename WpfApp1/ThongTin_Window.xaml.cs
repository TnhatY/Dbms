using Do_an;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.Entity;
using Do_an.config;
using Do_an.dao;
using System.Windows.Forms;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThongTin_Window.xaml
    /// </summary>
    public partial class ThongTin_Window : Window
    {
       
        public ThongTin_Window()
        {
            InitializeComponent();
        }
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        public static bool kthongtin= false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            F_Main.checkThemSp= false;
            kthongtin = false;
            try
            {
                
                SqlConnection conn = ConnectDB.getconnection();
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand($"SELECT * FROM DanhSachSanPham where MaSP = '{MaSP.Text}'", conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            MaSP.Text = reader["MaSP"].ToString();
                            TenSP.Text = reader["TenSP"].ToString();
                            TinhTrang.Text = reader["TinhTrang"].ToString();
                            GiaGoc.Text = reader["GiaGoc"].ToString();
                            GiaBan.Text = reader["GiaBan"].ToString();
                            TenLoaiSP.Text = reader["TenLoaiSP"].ToString();
                            TenNCC.Text = reader["TenNCC"].ToString();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(reader["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            HinhAnh.Source = bitmap;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click_1(object sender, RoutedEventArgs e)
        {
          
            Close();
        }

        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            ThanhToan_Window thanhToan_Window = new ThanhToan_Window();
            thanhToan_Window.masp.Text = MaSP.Text;
            thanhToan_Window.Show();
            this.Hide();
        }

      

        private void btnChinhSuaSP_Click(object sender, RoutedEventArgs e)
        {
            kthongtin = true;
            try
            {
                ThemSP_Window themSP_Window = new ThemSP_Window();
                SqlConnection conn = ConnectDB.getconnection();
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand($"SELECT * FROM SanPham where MaSP = '{MaSP.Text}'", conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            themSP_Window.txtMaSP.Text = reader["MaSP"].ToString();
                            themSP_Window.txtTenSP.Text = reader["TenSP"].ToString();
                            themSP_Window.txtTinhTrang.Text = reader["TinhTrang"].ToString();
                            themSP_Window.txtGiaGoc.Text = reader["GiaGoc"].ToString();
                            themSP_Window.txtGiaBan.Text = reader["GiaBan"].ToString();
                            themSP_Window.cbDanhMuc.SelectedItem = reader["MaLoaiSP"].ToString();
                            themSP_Window.cbNcc.SelectedItem = reader["MaNCC"].ToString();
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(reader["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                            bitmap.EndInit();
                            HinhAnh.Source = bitmap;
                        }
                    }
                }
                themSP_Window.ShowDialog();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaSP_Click(object sender, RoutedEventArgs e)
        {
           SanPham_DAO sanPhamDAO = new SanPham_DAO();
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                               "Xác nhận xóa",
                                               MessageBoxButton.YesNo,
                                               MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                sanPhamDAO.xoaSanPham(MaSP.Text);
                Close();
            }
        }
    }
}
