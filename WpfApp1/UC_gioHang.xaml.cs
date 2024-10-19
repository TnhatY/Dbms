using Do_an;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using System.Collections;

using System.Data;
using System.Windows.Markup;
using System.Data.Entity;

namespace Do_an
{
    public partial class UC_gioHang : UserControl
    {
        

        public UC_gioHang()
        {
            InitializeComponent();
           

            this.DataContext = this;
            this.Loaded += UC_gioHang_Loaded;
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listview_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

      

        private void UC_gioHang_Loaded(object sender, RoutedEventArgs e)
        {

           
           
        }
        public void ReloadData()
        {
          
        }

        private void xoa_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void themvoucher_Click(object sender, RoutedEventArgs e)
        {
            tittle.Text = "Danh sách mã giảm giá";
            ThemVoucher themVoucher = new ThemVoucher();
            themVoucher.ShowDialog();
        }

        private void themnhanvien_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
