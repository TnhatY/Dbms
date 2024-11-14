using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Do_an.dao;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_DoanhThuLoaiSanPham.xaml
    /// </summary>
    public partial class UC_DoanhThuLoaiSanPham : UserControl
    {
        public UC_DoanhThuLoaiSanPham()
        {
            InitializeComponent();
            // Gán dữ liệu cho ComboBox (danh sách tháng và năm)
            cb_thang.ItemsSource = Enumerable.Range(1, 12);
            cb_nam.ItemsSource = Enumerable.Range(2020, 10);

            // Thiết lập các giá trị mặc định cho ComboBox
            cb_thang.SelectedItem = DateTime.Now.Month;
            cb_nam.SelectedItem = DateTime.Now.Year;
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            HoaDon_DAO hoaDon_dao = new HoaDon_DAO();
            if (cb_thang.SelectedItem == null || cb_nam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm.");
                return;
            }

            int month = (int)cb_thang.SelectedItem;
            int year = (int)cb_nam.SelectedItem;

            // Gọi phương thức lấy dữ liệu từ cơ sở dữ liệu hoặc tính toán doanh thu
            var revenues = hoaDon_dao.GetRevenueByMonthAndYear(month, year);
            
            // Tạo và cập nhật SeriesCollection cho biểu đồ
            var revenueSeries = new ColumnSeries
            {
                Title = "Doanh Thu",
                Values = new ChartValues<double>(revenues.Select(r => r.RevenueAmount)),
                LabelPoint = chartPoint => chartPoint.Y.ToString()
            };

            RevenueChart.AxisX.Clear();  // Xóa trục X cũ nếu có
            RevenueChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Loại Sản Phẩm",
                Labels = revenues.Select(r => r.TenLoaiSP).ToArray(),  // Lấy tên loại sản phẩm để hiển thị trên trục X
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = true
                }
            });
            if (RevenueChart != null)
            {
                RevenueChart.Series.Clear();
                RevenueChart.Series.Add(revenueSeries);
            }
            else
            {
                MessageBox.Show("Không thể cập nhật biểu đồ.");
            }
        }
    }
}
