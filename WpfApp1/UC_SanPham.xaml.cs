using Do_an;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_SanPham.xaml
    /// </summary>
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
        }
        //public event EventHandler<DataEventArgs> DataRequested;

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ThongTin_Window thongTin_Window = new ThongTin_Window();
            thongTin_Window.MaSP.Text = masp.Text;
            thongTin_Window.ShowDialog();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
           
           
        }

    }
}
