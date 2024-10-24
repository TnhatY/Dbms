using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Do_an.dao
{
    public class NhanVien_DAO
    {
        public DataTable XemThongTinNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ThongTinNhanVien", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public List<UC_NhanVien> listNhanvien()
        {
            List<UC_NhanVien> list = new List<UC_NhanVien>();
            try
            {
                DataTable dt = XemThongTinNhanVien();

                foreach (DataRow dr in dt.Rows)
                {
                    UC_NhanVien nhanvien = new UC_NhanVien();
                    nhanvien.manv.Text = dr["MaNV"].ToString();
                    nhanvien.tennv.Text = dr["TenNV"].ToString();
                    nhanvien.sdt.Text = dr["SoDT"].ToString();
                    nhanvien.diachi.Text = dr["DiaChi"].ToString();
                    list.Add(nhanvien);
                }
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public DataTable tinhLuongNV(int nam,int thang)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_TinhLuongNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return null;
            }

        }

        public List<UC_NhanVien> timkiemNhanVien(string keyword)
        {
            List<UC_NhanVien> listnv = new List<UC_NhanVien>();
            using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("TimKiemNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNV", keyword);
                        cmd.Parameters.AddWithValue("@TenNV", keyword);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UC_NhanVien uC_NhanVien = new UC_NhanVien();
                                uC_NhanVien.tennv.Text = reader["TenNV"].ToString();
                                uC_NhanVien.manv.Text = reader["MaNV"].ToString();
                                uC_NhanVien.sdt.Text = reader["SoDT"].ToString();
                                uC_NhanVien.diachi.Text = reader["DiaChi"].ToString();
                                listnv.Add(uC_NhanVien);
                            }
                        }
                    }
                    return listnv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }

        }
    }
}
