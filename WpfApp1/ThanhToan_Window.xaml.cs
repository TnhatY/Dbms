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
using System.Data.SqlClient;


namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThanhToan_Window.xaml
    /// </summary>
    public partial class ThanhToan_Window : Window
    {
        public ThanhToan_Window()
        {
            InitializeComponent();
        }
     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            phivanchuyen.Text = "120";
            float giaBan = 0;
            float phiVanChuyen = float.Parse(phivanchuyen.Text);
            spmua.ItemsSource = null;
           
           
            sodiachi.SelectedIndex = 0;

         
            
        }
       
        private void themVoucher_Click(object sender, RoutedEventArgs e)
        {
            TongPhieuGiam tongPhieuGiam = new TongPhieuGiam();
            tongPhieuGiam.tenshop.Text = tenshop.Text;
            tongPhieuGiam.ShowDialog();
            if (TongPhieuGiam.checkgiamgia)
            {
                float phantramgiam = float.Parse(giaban1.Text) * PhieuGiamGia.phantramgiamgia / 100;
                float gb1 = float.Parse(giaban1.Text)- phantramgiam;
                float gb2 = float.Parse(tongthanhtoan.Text) - phantramgiam;
                tongthanhtoan.Text = tongthanhtoan1.Text = gb2.ToString();   
                giaban1.Text = gb1.ToString();
            }
        }
        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
         
        }
        
        private void thoat_Click(object sender, RoutedEventArgs e)
        {
          
            Close();
        }
    }
}
