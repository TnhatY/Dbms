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
    }
}
