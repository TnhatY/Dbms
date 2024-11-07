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
    }
}
