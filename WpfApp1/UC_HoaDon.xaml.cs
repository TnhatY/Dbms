using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for UC_HoaDon.xaml
    /// </summary>
    public partial class UC_HoaDon : UserControl
    {
        public UC_HoaDon()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM DanhMucHoaDon", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgHoaDon.ItemsSource = dataTable.DefaultView;
        }

        private void btntaohoadon_Click(object sender, RoutedEventArgs e)
        {
            TaoHoaDon taoHoaDon = new TaoHoaDon();
            taoHoaDon.ShowDialog();
        }

        public DataTable timKiemHD(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectDB.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_TimKiemHoaDon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                        command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }

            return dataTable;
        }


        private void btnTimkiem_Click(object sender, RoutedEventArgs e)
        {
            if (ngaybatdau.SelectedDate.HasValue && ngayketthuc.SelectedDate.HasValue)
            {
                DateTime ngaybatdau1 = ngaybatdau.SelectedDate.Value;
                DateTime ngayketthuc1 = ngayketthuc.SelectedDate.Value;
                dgHoaDon.ItemsSource = timKiemHD(ngaybatdau1, ngayketthuc1).DefaultView;
            }
            else
            {
                MessageBox.Show("Chưa chọn ngày");
            }
        }
    }
}
