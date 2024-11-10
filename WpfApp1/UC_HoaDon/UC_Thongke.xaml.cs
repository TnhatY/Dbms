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

		private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			ComboBoxItem? selectedItem = cb.SelectedItem as ComboBoxItem;
			string? content = selectedItem?.Content.ToString();
			
			cb_thang.Visibility = Visibility.Collapsed;
			cb_nam.Visibility = Visibility.Collapsed;

			if (content == "Doanh thu theo ngày")
			{
				lblChonThang.Visibility = Visibility.Visible;
				lblChonNam.Visibility = Visibility.Visible;
				cb_thang.Visibility = Visibility.Visible;
				cb_nam.Visibility = Visibility.Visible; 
			}
			else if (content == "Doanh thu theo tháng")
			{
				lblChonThang.Visibility = Visibility.Collapsed;
				lblChonNam.Visibility = Visibility.Visible;
				cb_nam.Visibility = Visibility.Visible; 
			}
			else if (content == "Doanh thu theo năm")
			{
				lblChonThang.Visibility = Visibility.Collapsed;
				lblChonNam.Visibility = Visibility.Collapsed;
				//LoadChartData("Nam", null, null); 
			}
			//LoadChartBySelection();
		}

		private void cb_thang_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//LoadChartBySelection();
		}

		private void LoadChartData(string type, int? month, int? year)
		{
			HoaDon_DAO hoaDonDao = new HoaDon_DAO();
			DataTable? data = null;
			if (type == "Ngay" && month.HasValue && year.HasValue)
			{
				data = hoaDonDao.layDoanhThu("Ngay" ,month.Value, year.Value);
			}
			else if (type == "Thang" && year.HasValue)
			{
				data = hoaDonDao.layDoanhThu("Thang", null, year.Value);
			}
			else if (type == "Nam")
			{
				data = hoaDonDao.layDoanhThu("Nam", null, null);
			}

			if (data == null)
			{
				MessageBox.Show("Không có dữ liệu cho khoảng thời gian đã chọn.");
				return;
			}

			LineSeries doanhThuSeries = new LineSeries
			{
				Title = $"Doanh thu theo {type}",
				Values = new ChartValues<float>()
			};

			List<string> labels = new List<string>();
			foreach (DataRow row in data.Rows)
			{
				string? label = type == "Ngay" ? row["Ngay"].ToString() : type == "Thang" ? row["Thang"].ToString() : row["Nam"].ToString();
				float doanhThu = Convert.ToSingle(row["DoanhThu"]);
				doanhThuSeries.Values.Add(doanhThu);
				labels.Add(label);
			}

			barChart.Series.Clear();
			barChart.Series.Add(doanhThuSeries);

			barChart.AxisX.Clear();
			barChart.AxisX.Add(new Axis
			{
				Title = type == "Ngay" ? "Ngày" : type == "Thang" ? "Tháng" : "Năm",
				Labels = labels
			});

			barChart.AxisY.Clear();
			barChart.AxisY.Add(new Axis
			{
				Title = "Doanh thu (VND)",
				LabelFormatter = value => value.ToString("N0")
			});
		}

		private void LoadChartBySelection()
		{
			///string conten = cb.SelectedItem.ToString();
			//MessageBox.Show(conten);
			ComboBoxItem? selectedItem = cb.SelectedItem as ComboBoxItem;
			string? content = selectedItem?.Content.ToString();

			if (content == "Doanh thu theo ngày" && cb_thang.SelectedItem != null && cb_nam.SelectedItem != null)
			{
				ComboBoxItem? selectedMonth = cb_thang.SelectedItem as ComboBoxItem;
				ComboBoxItem? selectedYear = cb_nam.SelectedItem as ComboBoxItem;

				if (int.TryParse(selectedMonth?.Content.ToString(), out int month) &&
					int.TryParse(selectedYear?.Content.ToString(), out int year))
				{
					LoadChartData("Ngay", month, year);
				}
			}
			else if (content == "Doanh thu theo tháng" && cb_nam.SelectedItem != null)
			{
				ComboBoxItem? selectedYear = cb_nam.SelectedItem as ComboBoxItem;

				if (int.TryParse(selectedYear?.Content.ToString(), out int year))
				{
					LoadChartData("Thang", null, year);
				}
			}
			else if (content == "Doanh thu theo năm")
			{
				LoadChartData("Nam", null, null);
			}
			//LoadChartData("Nam", null, null);	
		}

		private void btnThongKe_Click(object sender, RoutedEventArgs e)
		{
			LoadChartBySelection();
		}

        private void btnDudoandoanhthu_Click(object sender, RoutedEventArgs e)
        {
			UC_DuBaoDoanhThu uC_DuBaoDoanhThu = new UC_DuBaoDoanhThu();
			uC_DuBaoDoanhThu.ShowDialog();
        }
    }
}
