using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using System;
using System.Security.Cryptography;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges
{
    public partial class EditBooking : UserControl
    {
        private long _id;
        private Booking booking;
        public EditBooking(long id)
        {
            InitializeComponent();
            _id = id;
            OkBtn.Click += OkBtn_Click;
            BackBtn.Click += BackBtn_Click;
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ReservationControl();
        }

        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            try
            {
                booking.DataStart = DataStartCmb.SelectedDate.Value.ToString("d");
                booking.DataEnd = DataEndCmb.SelectedDate.Value.ToString("d");

                if (_id == -1)
                {
                    Db.Bookings.Add(booking);
                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new ReservationControl();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
