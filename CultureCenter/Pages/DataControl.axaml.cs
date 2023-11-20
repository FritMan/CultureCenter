using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
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
            SearchTB.TextChanged += SearchTB_TextChanged;
            LoadData();
        }

        private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private async void DeleteEventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedEvents = EventDG.SelectedItem as Event;
            if (selectedEvents != null)
            {
                if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                {
                    Db.Events.Remove(selectedEvents);
                    Db.SaveChanges();
                    NavigationSystem.MainFrame.Content = new DataControl();
                }
            }
            else
            {
                Helper.ShowInfo("Выберите мероприятие");
                return;
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
            if (string.IsNullOrEmpty(SearchTB.Text))
            {
                EventDG.ItemsSource = Db.Events;
            }
            else
            {
                EventDG.ItemsSource = Db.Events.Where(el => el.Description.Contains(SearchTB.Text));
            }
        }
    }
}
