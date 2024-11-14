using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Do_an.model;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Do_an.dao
{
    class HoaDon_DAO
    {
        ConnectDB db = new ConnectDB();

        public DataTable? layDoanhThu(string type, int? thang, int? nam)
        {
            string query = "";

            if (type == "Ngay" && thang.HasValue && nam.HasValue)
            {
                query = $"SELECT * FROM dbo.func_tinhDoanhThuNgay({thang.Value}, {nam.Value})";
            }
            else if (type == "Thang" && nam.HasValue)
            {
                query = $"SELECT * FROM dbo.func_tinhDoanhThuThang({nam.Value})";
            }
            else if (type == "Nam")
            {
                query = $"SELECT * FROM dbo.func_tinhDoanhThuNam()";
            }
            else
            {
                return null;
            }

            return new ConnectDB().getAllData(query);
        }

        

        public List<HoaDon.Revenue> GetRevenueByMonthAndYear(int month, int year)
        {
            SqlConnection connection = ConnectDB.getconnection();
            List<HoaDon.Revenue> revenues = new List<HoaDon.Revenue>();
            SqlDataAdapter adapter = new SqlDataAdapter("DoanhThuTheoLoaiSanPham", connection);
            try
            {
                // Chỉ định stored procedure và các tham số
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int) { Value = month });
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Nam", SqlDbType.Int) { Value = year });

                connection.Open();
                DataTable revenueData = new DataTable();
                adapter.Fill(revenueData);  // Lấy dữ liệu từ stored procedure vào DataTable

                // Chuyển dữ liệu từ DataTable sang List<HoaDon.Revenue>
                foreach (DataRow row in revenueData.Rows)
                {
                    HoaDon.Revenue revenue = new HoaDon.Revenue
                    {
                        TenLoaiSP = Convert.ToString(row["TenLoaiSP"]),
                        DoanhThu = (double)Convert.ToDecimal(row["DoanhThu"])
                    };
                    revenues.Add(revenue);
                }

                return revenues;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;  // Trả về null nếu có lỗi
            }
            finally
            {
                connection.Close();  // Đảm bảo kết nối được đóng
            }
        }
    }
}
