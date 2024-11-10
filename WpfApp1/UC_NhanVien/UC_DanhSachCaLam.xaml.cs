
using Do_an.dao;
using System;
using System.Collections.Generic;
using System.Data;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_DanhSachCaLam.xaml
    /// </summary>
    public partial class UC_DanhSachCaLam : UserControl
    {
        public String manv = "";
        public UC_DanhSachCaLam(String ID)
        {
            InitializeComponent();
            this.manv = ID;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void load(Object sender, RoutedEventArgs e)

        {
            CaLam_Dao cl = new CaLam_Dao();
            dg_danhsachcalam.ItemsSource = cl.findbyidnv(manv).DefaultView;
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            ThemCaLam_Window add = new ThemCaLam_Window();
            add.manv = manv;
            add.ShowDialog();
            this.load(sender, e);
        }

        private void Button_remove(object sender, RoutedEventArgs e)
        {

            if (dg_danhsachcalam.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    CaLam_Dao calam = new CaLam_Dao();
                    if (dg_danhsachcalam.SelectedItem is DataRowView selectedRow)
                    {
                        // Lấy giá trị của cột "maclv" từ dòng được chọn
                        String maclv = selectedRow["MaCLV"].ToString();
                        String ngaylam = selectedRow["NgayLam"].ToString();

                        // Chuyển chuỗi ngày thành DateTime
                        DateTime date = DateTime.ParseExact(ngaylam, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        // Định dạng lại DateTime thành chuỗi với định dạng "yyyy-MM-dd"
                        string formattedDateString = date.ToString("yyyy-MM-dd");

                        calam.xoa_CalamViec(manv, maclv, formattedDateString);
                        this.load(sender, e);
                    }
                }

            }

        }
    }
}
