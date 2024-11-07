using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Do_an.dao
{
    public class CaLam_Dao
    {
        private String maclv;
        private String manv;
        private DateTime ngaylam;

        public DataTable findbyidnv(String manv)
        {

            DataTable dt = new DataTable();
            String sql = $"select BangPhanCa.manv, BangPhanCa.MaCLV, BangPhanCa.NgayLam, CaLamViec.ThoiGianBatDau, CaLamViec.ThoiGianKetThuc from BangPhanCa join CaLamViec on BangPhanCa.MaCLV = CaLamViec.MaCLV where BangPhanCa.MaNV = '{manv}'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, ConnectDB.getconnection());
      
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            
        }
        public void xoa_CalamViec(string manv, string maclv,string ngaylam)
        {
            string sqlStr = $"exec proc_XoaPhanCa {manv},  {maclv},{ngaylam}";
            try
            {
                SqlConnection conn = ConnectDB.getconnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       public void them_CaLamViec(string manv, string maclv, string ngaylam)
        {
            string sqlStr = $"exec them_calamviec '{manv}',  '{maclv}', '{ngaylam}'";
            try
            {
                SqlConnection conn = ConnectDB.getconnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
