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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vipief.View;
using vipief.ViewModel;


namespace vipief
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>

   
    public partial class Page2 : Page
    {
        public string Kalendar1 { get; set; }
        public Page2()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
           

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = Next.ActualHeight; // Начальная высота кнопки
            heightAnimation.To = Next.ActualHeight * 2; // Конечная высота кнопки (увеличение в два раза)
            heightAnimation.Duration = TimeSpan.FromSeconds(1); // Продолжительность анимации (1 секунда)


            Next.BeginAnimation(Button.HeightProperty, heightAnimation);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = Back.ActualHeight; // Начальная высота кнопки
            heightAnimation.To = Back.ActualHeight * 2; // Конечная высота кнопки (увеличение в два раза)
            heightAnimation.Duration = TimeSpan.FromSeconds(1); // Продолжительность анимации (1 секунда)


            Back.BeginAnimation(Button.HeightProperty, heightAnimation);
        }
    }
}
