using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.dao
{
    class HoaDon_DAO
    {
		ConnectDB db = new ConnectDB();

		// Lấy doanh thu từng ngày trong một tháng cụ thể
		public List<KeyValuePair<string, float>> doanhThuTheoNgay(int thang, int nam)
		{
			List<KeyValuePair<string, float>> doanhThuNgay = new List<KeyValuePair<string, float>>();
			try
			{
				// Câu truy vấn SQL gọi hàm func_tinhDoanhThuNgay với tham số thang và nam
				string query = $"SELECT Ngay, DoanhThu FROM dbo.func_tinhDoanhThuNgay({thang}, {nam})";
				DataTable dt = db.getAllData(query);

				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						string ngay = row["Ngay"].ToString(); // Chuyển đổi ngày thành chuỗi
						float doanhThu = Convert.ToSingle(row["DoanhThu"]);
						doanhThuNgay.Add(new KeyValuePair<string, float>(ngay, doanhThu));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving daily revenue: {ex.Message}");
			}
			return doanhThuNgay;
		}


		// Lấy doanh thu từng tháng trong năm cụ thể
		public List<KeyValuePair<string, float>> doanhThuTheoThang(int nam)
		{
			List<KeyValuePair<string, float>> doanhThuThang = new List<KeyValuePair<string, float>>();
			try
			{
				// Query lấy dữ liệu từ hàm SQL mới
				string query = $"SELECT Thang, DoanhThu FROM dbo.[func_tinhDoanhThuThang]({nam})";
				DataTable dt = db.getAllData(query);

				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						string thang = row["Thang"].ToString(); // Lấy giá trị của tháng
						float doanhThu = Convert.ToSingle(row["DoanhThu"]); // Lấy giá trị doanh thu
						doanhThuThang.Add(new KeyValuePair<string, float>(thang, doanhThu)); // Thêm vào danh sách
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving monthly revenue: {ex.Message}");
			}
			return doanhThuThang;
		}


		// Lấy doanh thu từng năm
		public List<KeyValuePair<string, float>> doanhThuTheoNam()
		{
			List<KeyValuePair<string, float>> doanhThuNam = new List<KeyValuePair<string, float>>();
			try
			{
				// Câu truy vấn SQL gọi hàm func_tinhDoanhThuNam
				string query = "SELECT Nam, DoanhThu FROM dbo.func_tinhDoanhThuNam()";
				DataTable dt = db.getAllData(query);

				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						string nam = row["Nam"].ToString(); // Chuyển đổi năm thành chuỗi
						float doanhThu = Convert.ToSingle(row["DoanhThu"]);
						doanhThuNam.Add(new KeyValuePair<string, float>(nam, doanhThu));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving yearly revenue: {ex.Message}");
			}
			return doanhThuNam;
		}


	}
}
