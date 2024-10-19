
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Do_an
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            F_Main f_Main = new F_Main();
            f_Main.Show();
            

        }

       
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = passwordBox.Password;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/eye.png", UriKind.Relative));
            
        }
        
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTextBox.Text;
            passwordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Collapsed;
            eye.Source = new BitmapImage(new Uri("/image/uneye.png", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
