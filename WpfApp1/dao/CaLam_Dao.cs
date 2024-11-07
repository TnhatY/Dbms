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
        public void xoa_CalamViec(String manv, String maclv)
        {
            String sqlStr = $"exec xoa_calamviec {manv},  {maclv} ";
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
        public void insert_to_table_from_datatable(DataTable dt, String tableNameIntdatabase)
        {
            using (SqlConnection conn = ConnectDB.getconnection())
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = tableNameIntdatabase;

                    try
                    {
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

            }
        }

       public void them_CaLamViec(String manv, String maclv, String ngaylam)
        {
            String sqlStr = $"exec them_calamviec '{manv}',  '{maclv}', '{ngaylam}'";
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

        public DataTable get_thoikhoabieu()
        {
            DataTable dt = new DataTable();

            String sql = $"select * from getData_Thoikhoabieu() order by MaNV";
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
        public void auto_phanca(int numstaffpershift, Dictionary<String, Dictionary<String, List<String>>> staff_off, Dictionary<String, List<String>> shop_off, Dictionary<String, int> socatoida)
        {
            // typ listNhanvienkhonglam
            DataTable list_nhanvien = new DataTable();
            list_nhanvien.Columns.Add("manv", typeof(String));
            list_nhanvien.Columns.Add("thu", typeof(String));
            list_nhanvien.Columns.Add("ca", typeof(String));

            //type listCahd in sql
            DataTable list_cahd = new DataTable();
            list_cahd.Columns.Add("thu", typeof(String));
            list_cahd.Columns.Add("ca", typeof(String)); 
            list_cahd.Columns.Add("nextweekdate", typeof(DateTime));

            // đổ dữ liệu từ danh sách shop hoạt động vào datatable
            foreach (KeyValuePair<String, List<String>> item in shop_off)
            {
                String thu = item.Key;  
                foreach(String ca in item.Value)
                {
                    list_cahd.Rows.Add(thu, ca, null);
                }
            }
            // đổ dữ liệu và danh sách nhân viên và ca nhân viên đó không thể làm 
            foreach(KeyValuePair<String, Dictionary<String, List<String>>> x in staff_off)
            {
                String manv = x.Key;
                foreach(KeyValuePair<String, List<String>> thuvaca in x.Value)
                {
                    String thu = thuvaca.Key;
                    foreach(String ca in thuvaca.Value)
                    {
                        list_nhanvien.Rows.Add(manv, thu, ca);
                    }
                }
            }

            DataTable dieukienNhanVien = new DataTable();
            dieukienNhanVien.Columns.Add("manv");
            dieukienNhanVien.Columns.Add("socatoida");


            // manv và số ca tối đa nhân viên đó có thể làm được
            foreach (KeyValuePair<String, int> item in socatoida)
            {
                String manv = item.Key; 
                int toida = item.Value; 

                DataRow row = dieukienNhanVien.NewRow();    
                row[0] = manv;
                row[1] = toida;
                dieukienNhanVien.Rows.Add(row);
            }


            // Thêm dữ liệu mới vào bảng DieuKienNhanVien1

            insert_to_table_from_datatable(dieukienNhanVien, "DieuKienNhanVien1");

            // thêm dữ liệu mới vào bảng DieuKienNhanVien2

            insert_to_table_from_datatable(list_nhanvien, "DieuKienNhanVien2");

            using (SqlConnection conn = ConnectDB.getconnection())
            {
                conn.Open();

                // Tạo SqlCommand cho stored procedure
                using (SqlCommand cmd = new SqlCommand("auto_phanca", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số int
                        cmd.Parameters.Add(new SqlParameter("@tongsonvtrenca", SqlDbType.Int) { Value = numstaffpershift });

                        // Tạo SqlParameter cho DataTable và thiết lập kiểu SqlDbType.Structured
                        SqlParameter tableParam = new SqlParameter();
                        tableParam.ParameterName = "@shop";
                        tableParam.SqlDbType = SqlDbType.Structured;
                        tableParam.TypeName = "ListCahd"; // Tên table type trong SQL Server
                        tableParam.Value = list_cahd;

                        // Thêm parameter vào SqlCommand
                        cmd.Parameters.Add(tableParam);

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("lỗi" + ex);
                    }
                }
                MessageBox.Show("phân ca thành công");
            }
        }  
    }
}
