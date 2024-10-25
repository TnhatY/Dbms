using Do_an.dao;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Do_an
{

	public partial class UC_Thongke : UserControl
	{
		HoaDon_DAO hoaDonDao = new HoaDon_DAO();
		

		public UC_Thongke()
		{
			InitializeComponent();
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{

			LoadChartData();
		}

		private void dp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			LoadChartData();
		}

		private void LoadChartData()
		{
			try
			{
				DateTime? date = dp1.SelectedDate;

				if (date == null)
				{
					MessageBox.Show("Vui lòng chọn một ngày.");
					return;
				}

				// Lấy dữ liệu doanh thu theo ngày, tháng, năm
				List<KeyValuePair<string, float>> doanhThuNgay = hoaDonDao.doanhThuTheoNgay(date.Value.Month, date.Value.Year);
				List<KeyValuePair<string, float>> doanhThuThang = hoaDonDao.doanhThuTheoThang(date.Value.Year);
				List<KeyValuePair<string, float>> doanhThuNam = hoaDonDao.doanhThuTheoNam();

				// Tạo các LineSeries cho từng loại dữ liệu (ngày, tháng, năm)
				LineSeries lineSeriesNgay = new LineSeries
				{
					Title = "Doanh thu ngày",
					Values = new ChartValues<float>(doanhThuNgay.Select(x => x.Value)),
					LineSmoothness = 0,
					Stroke = new SolidColorBrush(Colors.Blue),
					Fill = Brushes.Transparent,
					PointGeometry = DefaultGeometries.Circle, // Hiển thị các điểm
					DataLabels = true, // Hiển thị nhãn
					LabelPoint = point => $"{doanhThuNgay[(int)point.X].Key}: {point.Y:N0}" // Hiển thị nhãn chứa ngày và giá trị
				};

				LineSeries lineSeriesThang = new LineSeries
				{
					Title = "Doanh thu tháng",
					Values = new ChartValues<float>(doanhThuThang.Select(x => x.Value)),
					LineSmoothness = 0,
					Stroke = new SolidColorBrush(Colors.Red),
					Fill = Brushes.Transparent,
					PointGeometry = DefaultGeometries.Circle, // Hiển thị các điểm
					DataLabels = true, // Hiển thị nhãn
					LabelPoint = point => $"Tháng {doanhThuThang[(int)point.X].Key} - {date.Value.Year}: {point.Y:N0}" // Hiển thị nhãn chứa tháng và năm
				};

				LineSeries lineSeriesNam = new LineSeries
				{
					Title = "Doanh thu ",
					Values = new ChartValues<float>(doanhThuNam.Select(x => x.Value)),
					LineSmoothness = 0,
					Stroke = new SolidColorBrush(Colors.Yellow),
					Fill = Brushes.Transparent,
					PointGeometry = DefaultGeometries.Circle, // Hiển thị các điểm
					DataLabels = true, // Hiển thị nhãn
					LabelPoint = point => $"Năm {doanhThuNam[(int)point.X].Key}: {point.Y:N0}" // Hiển thị nhãn chứa năm
				};

				List<string> labels = doanhThuNgay.Select(x => x.Key).ToList(); // Danh sách nhãn cho trục X

				// Xóa dữ liệu cũ và thêm các series mới
				barChart.Series.Clear();
				barChart.Series.Add(lineSeriesNgay);
				barChart.Series.Add(lineSeriesThang);
				barChart.Series.Add(lineSeriesNam);

				// Cập nhật trục X với nhãn tương ứng
				barChart.AxisX.Clear();
				barChart.AxisX.Add(new Axis
				{
					Title = "Thời gian",
					Labels = labels
				});

				// Cập nhật trục Y
				barChart.AxisY.Clear();
				barChart.AxisY.Add(new Axis
				{
					Title = "Doanh thu (VND)",
					LabelFormatter = value => value.ToString("N0") // Định dạng giá trị doanh thu
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading chart data: {ex.Message}");
			}
		}


	}
}