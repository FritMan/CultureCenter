using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var selectedTypes = TypesOfEventDG.SelectedItem as TypesOfEvent;
            if (selectedTypes != null)
            {
                Db.TypesOfEvents.Remove(selectedTypes);
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new DataControl();
            }
        }

        private void EditTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedTypes = TypesOfEventDG.SelectedItem as TypesOfEvent;
            if (selectedTypes != null)
            {
                NavigationSystem.MainFrame.Content = new TypesEdit(selectedTypes.Id);
            }
        }

        private void AddTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new TypesEdit(-1);
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new IntermediateMenu();
        }

        private void LoadData()
        {
            Db.TypesOfEvents.Load();
            Db.Events.Load();
            TypesOfEventDG.ItemsSource = Db.TypesOfEvents;
        }
    }
}
