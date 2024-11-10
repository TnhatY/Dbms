using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
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
using System.Data.SqlClient;
using Do_an.config;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for TaoHoaDon.xaml
    /// </summary>
    public partial class TaoHoaDon : Window
    {
        public TaoHoaDon()
        {
            InitializeComponent();
        }

        public void XuatHoaDon(string maHD, DateTime ngayXuatHD, string maKH, string maNV, float triGiaHD)
        {
            using (SqlConnection connection = new SqlConnection(ConnectDB.connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("proc_AddHoaDon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MaHD", maHD);
                        command.Parameters.AddWithValue("@NgayXuatHD", ngayXuatHD);
                        command.Parameters.AddWithValue("@TriGiaHD", triGiaHD);
                        command.Parameters.AddWithValue("@MaKH", maKH);
                        command.Parameters.AddWithValue("@MaNV", maNV);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xuất hoá đơn thành công!");
                            
                        }
                        else
                        {
                            MessageBox.Show("Không thể xuất hóa đơn.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        public void quydoidiem(string maKH,int diemQuyDoi)
        {
            using (SqlConnection connection = new SqlConnection(ConnectDB.connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("proc_QuyDoiDiem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MaKH", maKH);
                        command.Parameters.AddWithValue("@DiemQuyDoi", diemQuyDoi);

                        int rowsAffected = command.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXuatHoaDon_Click(object sender, RoutedEventArgs e)
        {
            DateTime ngayGioHienTai = DateTime.Today;
            try
            {
                XuatHoaDon(txtMahd.Text, ngayGioHienTai, txtMakh.Text, txtManv.Text, float.Parse(txtTrigiahd.Text));
                string sql = "INSERT INTO ChiTietHoaDon (MaSP, MaHD,SoLuong) VALUES (@masp, @mahd,@soluong)";
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@masp", masp.Text);
                    command.Parameters.AddWithValue("@mahd", txtMahd.Text);
                    command.Parameters.AddWithValue("@soluong", 1);
                    command.ExecuteNonQuery();
                }
                Close();
                quydoidiem(txtMakh.Text,int.Parse(diemquydoi.Text));

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
