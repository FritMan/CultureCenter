using Avalonia.Controls;
using Avalonia.Media;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class ReservationControl : UserControl
    {
        public ReservationControl()
        {
            InitializeComponent();
            AddBookingBtn.Click += AddBookingBtn_Click;
            EditBookingBtn.Click += EditBookingBtn_Click;
            DeleteBookingBtn.Click += DeleteBookingBtn_Click;
            BackBtn.Click += BackBtn_Click;
            SearchTB.TextChanging += SearchTB_TextChanging;
            LoadData();
            
        }

        private void LoadData()
        {
            Db.Events.Load();
            Db.Rooms.Load();
            if (string.IsNullOrEmpty(SearchTB.Text))
            {
                ReservationDG.ItemsSource = Db.Bookings;
            }
            else
            {
                ReservationDG.ItemsSource = Db.Bookings.Where(el => el.Events.Description.Contains(SearchTB.Text));
            }
        }
    

        private void SearchTB_TextChanging(object? sender, TextChangingEventArgs e)
        {
            LoadData();

        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new IntermediateMenu();
        }

        private async void DeleteBookingBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           try
            {
                var selectedBooking = ReservationDG.SelectedItem as Booking;
                if (selectedBooking != null)
                {
                    if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                    {
                        Db.Bookings.Remove(selectedBooking);
                        Db.SaveChanges();
                        NavigationSystem.MainFrame.Content = new ReservationControl();
                    }
                }
                else
                {
                    Helper.ShowInfo("Выберите мероприятие");
                    return;
                }
            }
            catch
            {

            }
           
        }

        private void EditBookingBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            var selectedBooking = ReservationDG.SelectedItem as Booking;
            if (selectedBooking != null)
            {
                NavigationSystem.MainFrame.Content = new EditBooking(selectedBooking.Id, 0);
            }
            
        }

        private void AddBookingBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           NavigationSystem.MainFrame.Content = new EditBooking(-1, 0);
        }
    }
}
