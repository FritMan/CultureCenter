using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class ControlTypes : UserControl
    {
        public ControlTypes()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
            AddTypesBtn.Click += AddTypesBtn_Click;
            EditTypesBtn.Click += EditTypesBtn_Click;
            DeleteTypesBtn.Click += DeleteTypesBtn_Click;
            LoadData();
        }

        private void DeleteTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void EditTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void AddTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new IntermediateMenu();
        }

        private void LoadData()
        {
            Db.TypesOfEvents.Load();
            TypesOfEventDG.ItemsSource = Db.TypesOfEvents;
        }
    }
}
