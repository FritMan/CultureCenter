using Avalonia.Controls;
using CultureCenter.Classes;
using Microsoft.EntityFrameworkCore;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class Days : UserControl
    {
        public Days()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
            LoadData();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ControlEducation();
        }

        private void LoadData()
        {
            Db.DaysOfWeeks.Load();
            DaysDG.ItemsSource = Db.DaysOfWeeks;
        }
    }
}
