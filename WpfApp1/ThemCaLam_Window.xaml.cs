using Do_an.dao;
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
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public String manv;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nv = new NhanVien_DAO();
            DateTime selectedDate = datetime.SelectedDate.Value;
            nv.them_CaLamViec(manv, this.txt_maclv.Text, selectedDate, start.Text, end.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
