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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for TongPhieuGiam.xaml
    /// </summary>
    public partial class TongPhieuGiam : Window
    {
        public TongPhieuGiam()
        {
            InitializeComponent();
        }
        
        public static bool checkgiamgia = false;
        public static string ten = "";
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }catch(Exception ex)
            {
                MessageBox.Show("Hiện chưa có mã giảm giá nào!");
                Close();
            }
        }

        private void chon_Click(object sender, RoutedEventArgs e)
        {
            checkgiamgia=true;
            Close();
        }
    }
}
