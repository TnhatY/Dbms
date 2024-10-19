using Do_an;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Interaction logic for ThemVoucher.xaml
    /// </summary>
    public partial class ThemVoucher : Window
    {
        public ThemVoucher()
        {
            InitializeComponent();
        }
       
        private void them_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (makm.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Mã khuyến mãi!");
                    return;
                }
                if (tenkm.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Tên khuyến mãi!");
                    return;
                }
                if (phantram.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập Phầm trăm giảm giá!");
                    return;
                }
               
                Close();

            }catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
