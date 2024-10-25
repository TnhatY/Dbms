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
    /// Interaction logic for XoaCaLamViec_Window.xaml
    /// </summary>
    public partial class XoaCaLamViec_Window : Window
    {
        public XoaCaLamViec_Window()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public String manv;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nv = new NhanVien_DAO();
            nv.xoa_CalamViec(manv, this.txt_maclv.Text());
            this.Close();   
        }
    }
}
