using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Do_an.config;
using System.Data.SqlClient;
using System.Windows;

namespace Do_an.dao
{
    public class KhachHang_DAO
    {
        public DataTable TimKiemKhachHang(string sdt)
        {
            DataTable dtKhachHang = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchKH(@SDT)", ConnectDB.getconnection());
                cmd.Parameters.AddWithValue("@SDT", sdt);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtKhachHang);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return dtKhachHang;
        }

        public void ThemKhachHang(string maKH, string tenKH, string diaChi, string sdt)
        {
           
            SqlConnection connection = ConnectDB.getconnection();
            connection.Open();
            SqlCommand command = new SqlCommand("ThemKhachHang", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@MaKH", maKH);
            command.Parameters.AddWithValue("@TenKH", tenKH);
            command.Parameters.AddWithValue("@DiaChi", diaChi);
            command.Parameters.AddWithValue("@SDT", sdt);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            connection.Close();
        }


    }
}
