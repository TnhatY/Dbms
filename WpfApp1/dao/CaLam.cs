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
    public class Calam
    {
        private String maclv;
        private String manv;
        private DateTime ngaylam;

        public DataTable findbyidnv(String manv)
        {

            DataTable dt = new DataTable();
            String sql = $"select * from BangPhanCa join CaLamViec on BangPhanCa.MaCLV = CaLamViec.MaCLV where BangPhanCa.MaNV = '{manv}'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, ConnectDB.getconnection());
      
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            return dt;
        }

    }
}
