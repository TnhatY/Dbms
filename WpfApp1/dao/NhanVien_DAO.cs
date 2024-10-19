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
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
           
        }

    }
}
