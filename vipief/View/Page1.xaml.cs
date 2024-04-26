using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using vipief.Model;
using vipief.View;
using vipief.ViewModel;

namespace vipief
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        public class Item
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public bool IsSelected { get; set; }
        }
        private List<Item> selectedItems = new List<Item>();
        public string Kalendar2 { get; set; }
       


        public Page1()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Backpage_Click(object sender, RoutedEventArgs e)
        {
            
           
            (Application.Current.MainWindow as MainWindow).PageFrame.Content = new Page2();
        }

        

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            string name = checkBox.Content.ToString();
            string imageUrl = GetImageSource(checkBox);
            selectedItems.Add(new Item { Name = name, ImageUrl = imageUrl, IsSelected = true });
        }
        private void Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {

            CheckBox checkBox = sender as CheckBox;
            string name = checkBox.Content.ToString();
            var itemToRemove = selectedItems.Find(item => item.Name == name);
            if (itemToRemove != null)
                selectedItems.Remove(itemToRemove);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = Save.ActualHeight; 
            heightAnimation.To = Save.ActualHeight * 2; 
            heightAnimation.Duration = TimeSpan.FromSeconds(1); 


            Save.BeginAnimation(Button.HeightProperty, heightAnimation);
            string json = JsonConvert.SerializeObject(selectedItems, Formatting.Indented);
            File.WriteAllText("selectedItems.json", json);
        }

        private string GetImageSource(CheckBox checkBox)
        {
           
            StackPanel stackPanel = checkBox.Parent as StackPanel;
            if (stackPanel != null && stackPanel.Children.Count > 0 && stackPanel.Children[0] is Image image)
            {
                return image.Source?.ToString();
            }
            return null;
        }

    }
}
