using Do_an;
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
    /// Interaction logic for TopSanPham_Window.xaml
    /// </summary>
    public partial class TopSanPham_Window : Window
    {
        
        public TopSanPham_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void thoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
