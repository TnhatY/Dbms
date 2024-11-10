
using Do_an.dao;
using DocumentFormat.OpenXml.Wordprocessing;
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
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThemCaLam_Window.xaml
    /// </summary>
    public partial class ThemCaLam_Window : Window
    {
        public ThemCaLam_Window()
        {
            InitializeComponent();
            load_combobox();
        }

        void load_combobox()
        {
            cbb_maclv.Items.Add("ca 1");
            cbb_maclv.Items.Add("ca 2");
            cbb_maclv.Items.Add("ca 3");

        }
        public String manv;
        CaLam_Dao caLam = new CaLam_Dao();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbb_maclv.Text.Length > 0)
                {
                    NhanVien_DAO nv = new NhanVien_DAO();
                    DateTime selectedDate = datetime.SelectedDate.Value;
                    String year = selectedDate.Year.ToString();
                    String month = selectedDate.Month.ToString();
                    String day = selectedDate.Day.ToString();
                    string dateString = $"{year}-{month}-{day}";
                    caLam.them_CaLamViec(manv, cbb_maclv.Text, dateString);
                    MessageBox.Show("Thêm ca làm việc thành công");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
