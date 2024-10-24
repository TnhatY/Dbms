using MaterialDesignThemes.Wpf;
using Microsoft.VisualBasic.ApplicationServices;
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
    /// Interaction logic for UC_NhanVien.xaml
    /// </summary>
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void xemchitiet_Click(object sender, RoutedEventArgs e)
        {
            UC_XemChiTietNhanVien detail_Empl = new UC_XemChiTietNhanVien();
            detail_Empl.manv = this.manv.Text;
        }
    }
}
