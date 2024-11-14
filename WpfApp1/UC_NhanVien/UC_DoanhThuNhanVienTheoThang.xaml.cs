using Do_an.dao;
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

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_DoanhThuNhanVienTheoThang.xaml
    /// </summary>
    public partial class UC_DoanhThuNhanVienTheoThang : UserControl
    {
        public UC_DoanhThuNhanVienTheoThang()
        {
            InitializeComponent();
            cb_thang.ItemsSource = Enumerable.Range(1, 12);
            cb_nam.ItemsSource = Enumerable.Range(2020, 10);
            cb_thang.SelectedItem = DateTime.Now.Month;
            cb_nam.SelectedItem = DateTime.Now.Year;
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nhanVien_dao = new NhanVien_DAO();
            if (cb_thang.SelectedItem == null || cb_nam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm.");
                return;
            }

            int month = (int)cb_thang.SelectedItem;
            int year = (int)cb_nam.SelectedItem;
            var revenues = nhanVien_dao.GetRevenueByEmployee(month, year);

            RevenueChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh Thu",
                    Values = new ChartValues<double>(revenues.Select(r => r.DoanhThu))
                }
            };

            RevenueChart.AxisX.Clear();
            RevenueChart.AxisX.Add(new Axis
            {
                Title = "Nhân viên",
                Labels = revenues.Select(r => r.TenNhanVien).ToArray(),
                Separator = new LiveCharts.Wpf.Separator()
            });

            RevenueChart.AxisY.Clear();
            RevenueChart.AxisY.Add(new Axis
            {
                Title = "Doanh Thu",
                LabelFormatter = value => value.ToString("N0")
            });

        }
    }
}