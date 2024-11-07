using Do_an;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Do_an.config;
using System.Data;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThemSP_Window.xaml
    /// </summary>
    public partial class ThemSP_Window : Window
    {
       
        public ThemSP_Window()
        {
            InitializeComponent();
        }
       
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Image_Button(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filePath, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                HinhAnh.Source = bitmap;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectDB connectDB = new ConnectDB();
            string sqlncc = "Select MaNCC from NhaCungCap";
            List<string> ncc = new List<string>();
            DataTable dt = connectDB.getAllData(sqlncc);
            foreach (DataRow dr in dt.Rows)
            {
                ncc.Add(dr[0].ToString());
            }
            cbNcc.ItemsSource = ncc;
            string sqllsp = "Select MaLoaiSP from LoaiSanPham";
            List<string> lsp = new List<string>();
            DataTable dt1 = connectDB.getAllData(sqllsp);
            foreach (DataRow dr in dt1.Rows)
            {
                lsp.Add(dr[0].ToString());
            }

            cbDanhMuc.ItemsSource = lsp;

            if (F_Main.checkThemSp == true)
            {
                btnchinhsua.Visibility = Visibility.Collapsed;
                btnThem.Visibility = Visibility.Visible;
            }
            else if (ThongTin_Window.kthongtin)
            {
                btnThem.Visibility = Visibility.Collapsed;
                btnchinhsua.Visibility = Visibility.Visible;
            }
        }
        

        private void btnThem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_ThemSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@MaLoaiSP", cbDanhMuc.SelectedItem);
                        cmd.Parameters.AddWithValue("@TinhTrang", txtTinhTrang.Text);
                        cmd.Parameters.AddWithValue("@GiaGoc", float.Parse(txtGiaGoc.Text));
                        cmd.Parameters.AddWithValue("@GiaBan", float.Parse(txtGiaBan.Text));
                        cmd.Parameters.AddWithValue("@MaNCC", cbNcc.SelectedItem);

                        cmd.Parameters.AddWithValue("@HinhAnh", HinhAnh.Source.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm sản phẩm thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm sản phẩm.");
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO KhoHang (MaSP, SoLuong) VALUES (@MaSP, @SoLuong)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@SoLuong", 10);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                           // MessageBox.Show("Thêm sản phẩm thành công.");
                          
                        }
                       
                    }

                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChinhSua(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_CapNhatSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maloai", cbDanhMuc.Text);
                        cmd.Parameters.AddWithValue("@mancc", cbNcc.Text.Trim());
                        cmd.Parameters.AddWithValue("@masp", txtMaSP.Text);
                        cmd.Parameters.AddWithValue("@tensp", txtTenSP.Text);
                        cmd.Parameters.AddWithValue("@tinhtrang", txtTinhTrang.Text);
                        cmd.Parameters.AddWithValue("@giagoc", float.Parse(txtGiaGoc.Text));
                        cmd.Parameters.AddWithValue("@giaban", float.Parse(txtGiaBan.Text));
                        cmd.Parameters.AddWithValue("@hinhanh", HinhAnh.Source.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sửa sản phẩm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Sửa không thành công");
                        }
                    }
                }
                Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    // Hiển thị thông báo lỗi khác nếu không phải lỗi quyền
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }


        }

        private void btnXoa(object sender, RoutedEventArgs e)
        {

           
        }
    }
}