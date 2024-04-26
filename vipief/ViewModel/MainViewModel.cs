using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using vipief.card;
using vipief.Model;
using vipief.ViewModel.Helpers;
using static vipief.Model.Kalendar;


namespace vipief.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        private DateTime day = DateTime.Now;

        private string kalendar1;
        public string Kalendar1
        {
            get { return kalendar1; }
            set
            {
                kalendar1 = value;
                OnPropertyChanged();
            }
        }

        private string kalendar2;
        public string Kalendar2
        {
            get { return kalendar2; }
            set
            {
                kalendar2 = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<UserControl1> daysOfMonth;
        public ObservableCollection<UserControl1> DaysOfMonth
        {
            get { return daysOfMonth; }
            set
            {
                daysOfMonth = value;
                OnPropertyChanged();
            }
        }

        public BindableCommand Nextcommand { get; set; }
        public BindableCommand Backcommand { get; set; }


        public MainViewModel()
        {
            DaysOfMonth = new ObservableCollection<UserControl1>();
           
            Text();

            
            foreach (var userControl in DaysOfMonth)
            {
                userControl.DaySelected += UserControl_DaySelected;
            }

            Nextcommand = new BindableCommand(_ => Next());
            Backcommand = new BindableCommand(_ => Back());
        }

       
        private void UserControl_DaySelected(object sender, string day)
        {
           
            Kalendar2 = day;
        }



        private void Text()
        {
            Kalendar1 = day.ToString("MMMM, yyyy");

            DaysOfMonth.Clear();

            for (int i = 1; i <= DateTime.DaysInMonth(day.Year, day.Month); i++)
            {
                UserControl1 d = new UserControl1();
                d.Day = i.ToString();
                DaysOfMonth.Add(d);
            }
        }

        private void Next()
        {
            day = day.AddMonths(1);
            Text();
        }

        private void Back()
        {
            day = day.AddMonths(-1);
            Text();
        }
    }





}

