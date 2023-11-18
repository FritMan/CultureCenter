using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class DataControl : UserControl
    {
        public DataControl()
        {
            InitializeComponent();
            AddEventBtn.Click += AddEventBtn_Click;
            EditEventBtn.Click += EditEventBtn_Click;
            DeleteEventBtn.Click += DeleteEventBtn_Click;
            BackBtn.Click += BackBtn_Click;
            LoadData();
        }

        private void DeleteEventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedEvent = EventDG.SelectedItem as Event;
            if (selectedEvent != null)
            {
                Db.Events.Remove(selectedEvent);
                Db.SaveChanges();
            }
        }

        private void EditEventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedEvent = EventDG.SelectedItem as Event;
            if (selectedEvent != null)
            {
                NavigationSystem.MainFrame.Content = new EventEdit(selectedEvent.Id);
            }
        }

        private void AddEventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new EventEdit(-1);
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new IntermediateMenu();
        }

        private void LoadData()
        {
            Db.Events.Load();
            Db.TypesOfEvents.Load();
            EventDG.ItemsSource = Db.Events;
        }
    }
}
