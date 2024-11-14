using Do_an.config;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Do_an.UC_DuBaoDoanhThu;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_DuBaoDoanhThu.xaml
    /// </summary>
    public partial class UC_DuBaoDoanhThu : Window
    {
        public UC_DuBaoDoanhThu()
        {
            InitializeComponent();
            LoadChartData();
            DataContext = this;
        }

        public class DuBaoDoanhThuData
        {
            public int ThangHienTai { get; set; }
            public int NamHienTai { get; set; }
            public decimal DoanhThuThangHienTai { get; set; }
            public int SoNgayCoGiaoDich { get; set; }
            public decimal DoanhThuTrungBinhNgay { get; set; }
            public decimal TyLeTangTruongTrungBinh3Thang { get; set; }
            public int ThangDuBao { get; set; }
            public int NamDuBao { get; set; }
            public int SoNgayThangDuBao { get; set; }
            public decimal DuBaoDoanhThuThangToi { get; set; }
        }

        

    public List<DuBaoDoanhThuData> GetDuBaoDoanhThuData()
    {
        List<DuBaoDoanhThuData> dataList = new List<DuBaoDoanhThuData>();
       
        using (SqlConnection connection = new SqlConnection(ConnectDB.connectionString))
        {
            SqlCommand command = new SqlCommand("proc_DuBaoDoanhThu_ChiTiet", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dataList.Add(new DuBaoDoanhThuData
                    {
                        ThangHienTai = reader.GetInt32(0),
                        NamHienTai = reader.GetInt32(1),
                        DoanhThuThangHienTai = reader.GetDecimal(2),
                        SoNgayCoGiaoDich = reader.GetInt32(3),
                        DoanhThuTrungBinhNgay = reader.GetDecimal(4),
                        TyLeTangTruongTrungBinh3Thang = reader.GetDecimal(5),
                        ThangDuBao = reader.GetInt32(6),
                        NamDuBao = reader.GetInt32(7),
                        SoNgayThangDuBao = reader.GetInt32(8),
                        DuBaoDoanhThuThangToi = reader.GetDecimal(9)
                    });
                }
            }
        }
        return dataList;
    }
        public string ThongTinThangHienTai { get; set; }
        public string ThongTinTyLeTangTruong { get; set; }
        public string ThongTinDuBao { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LoadChartData()
        {
            List<DuBaoDoanhThuData> dataList = GetDuBaoDoanhThuData();

            if (dataList.Count > 0)
            {
                // Lấy bản ghi đầu tiên để hiển thị
                var data = dataList[0];

                // Thông tin tháng hiện tại
                ThongTinThangHienTai = $"Tháng {data.ThangHienTai}/{data.NamHienTai}\n" +
                                       $"- Số ngày có giao dịch: {data.SoNgayCoGiaoDich}\n" +
                                       $"- Doanh thu trung bình ngày: {data.DoanhThuTrungBinhNgay:C}\n" +
                                       $"- Tổng doanh thu tháng: {data.DoanhThuThangHienTai:C}";

                // Tỷ lệ tăng trưởng trung bình 3 tháng
                ThongTinTyLeTangTruong = $"Tỷ lệ tăng trưởng trung bình 3 tháng gần nhất: {data.TyLeTangTruongTrungBinh3Thang:P}";

                // Dự báo doanh thu tháng tới
                ThongTinDuBao = $"Dự báo doanh thu cho tháng {data.ThangDuBao}/{data.NamDuBao}:\n" +
                                $"- Số ngày dự kiến: {data.SoNgayThangDuBao}\n" +
                                $"- Doanh thu dự báo: {data.DuBaoDoanhThuThangToi:C}";
            }
        }
    }
}
