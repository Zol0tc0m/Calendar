using System;
using System.Collections.Generic;
using System.IO;
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
using vipief.View;
using vipief.ViewModel;

namespace vipief.card
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        
        public event EventHandler<string> DaySelected;
        public string Day { get; set; }
       

        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
           


        }

        

        

        private void Look_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).PageFrame.Content = new Page1();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            DaySelected?.Invoke(this, Day);

            (Application.Current.MainWindow as MainWindow).PageFrame.Content = new Page1();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("selectedItems.json", string.Empty);
        }
    }
}
