using Do_an.config;
using Do_an.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Do_an.dao
{
    public class SanPham_DAO
    {
        public static SqlDataAdapter adapter;
        public static SqlCommand cmd;
      


        public DataTable XemDanhMucSanPham()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DanhSachSanPham ", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public List<SanPham> timkiemSP(string keyword)
        {
            try
            {
                List<SanPham> sanPhams = new List<SanPham>();
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.TimKiemSanPham(@keyword)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", keyword);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            string maSP = row["MaSP"].ToString();
                            string tenSP = row["TenSP"].ToString();
                            float giaGoc = Convert.ToSingle(row["GiaGoc"]);
                            float giaBan = Convert.ToSingle(row["GiaBan"]);
                            string hinhAnh = row["HinhAnh"].ToString();

                            sanPhams.Add(new SanPham(maSP, tenSP, giaGoc, giaBan, hinhAnh));
                        }
                    }
                }
                return sanPhams;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return null;
            }
        }

        public void themSanPham(SanPham sanPham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_ThemSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaSP", sanPham.MaSP);
                        cmd.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                        cmd.Parameters.AddWithValue("@MaLoaiSP", sanPham.DanhMucSP);
                        cmd.Parameters.AddWithValue("@TinhTrang", sanPham.TinhTrang);
                        cmd.Parameters.AddWithValue("@GiaGoc", sanPham.GiaGoc);
                        cmd.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                        cmd.Parameters.AddWithValue("@MaNCC", sanPham.NhaCC);
                        cmd.Parameters.AddWithValue("@HinhAnh", sanPham.HinhAnh);

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<SanPham> listSP()
        {
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            DataTable dt = sanPham_DAO.XemDanhMucSanPham();
            List<SanPham> sanPhams = new List<SanPham>();
            try {
               
                foreach (DataRow row in dt.Rows)
                {
                    string maSP = row["MaSP"].ToString();
                    string tenSP = row["TenSP"].ToString();
                    float giaGoc = Convert.ToSingle(row["GiaGoc"]);
                    float giaBan = Convert.ToSingle(row["GiaBan"]);
                    string hinhAnh = row["HinhAnh"].ToString();
                    
                    sanPhams.Add(new SanPham(maSP, tenSP, giaGoc,giaBan, hinhAnh));
                }
                return sanPhams;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void xoaSanPham(string masp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_XoaSanPham", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaSP", masp);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xoá sản phẩm thành công");
                        }
                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }   
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
    }
}
