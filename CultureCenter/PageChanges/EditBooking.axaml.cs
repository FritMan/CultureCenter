using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges
{

    
    public partial class EditBooking : UserControl
    {
        private long _id;
        private Booking booking;
        private int _backPath = 0;
        private int _eventId = 0;
        private int _roomId = 0;
        public EditBooking(long id, int backPath)
        {
            InitializeComponent();
            _id = id;
            _backPath = backPath;
            OkBtn.Click += OkBtn_Click;
            BackBtn.Click += BackBtn_Click;
            DataStartCmb.SelectedDateChanged += DataStartCmb_SelectedDateChanged;
            DataEndCmb.SelectedDateChanged += DataEndCmb_SelectedDateChanged;
            DataCreationCmb.SelectedDate = DateTime.Now;
            DataStartCmb.SelectedDate = DateTime.Now;
            DataEndCmb.SelectedDate = DateTime.Now;
            DataEndCmb.DisplayDateStart = DataStartCmb.SelectedDate.Value;
            loadRooms();
            loadData();
        }

        private void loadRooms()
        {
            try
            {
                var allRooms = Db.Rooms.ToList();
                List<Room> reservedRooms = new List<Room>();

                foreach (var el in Db.Bookings)
                {
                    if (DateTime.Parse(el.DataStart).Date <= DataStartCmb.SelectedDate.Value.Date &&
                        DateTime.Parse(el.DataEnd).Date >= DataStartCmb.SelectedDate.Value.Date ||
                        DateTime.Parse(el.DataStart).Date <= DataEndCmb.SelectedDate.Value.Date &&
                        DateTime.Parse(el.DataEnd).Date >= DataEndCmb.SelectedDate.Value.Date)
                    {
                        reservedRooms.Add(el.Room);
                    }
                }
                reservedRooms = reservedRooms.Distinct().ToList();
                var emptyRooms = allRooms.Except(reservedRooms);
                RoomCb.ItemsSource = emptyRooms;
            }
            catch { }
        }

        private void DataStartCmb_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            loadRooms();
            DataEndCmb.DisplayDateStart = DataStartCmb.SelectedDate;
            if (DataEndCmb.SelectedDate.Value < DataStartCmb.SelectedDate.Value)
            {
                DataEndCmb.SelectedDate = DataStartCmb.SelectedDate;
                DataEndCmb.DisplayDateStart = DataStartCmb.SelectedDate;
            }
        }

        private void DataEndCmb_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            loadRooms();
            DataEndCmb.DisplayDateStart = DataStartCmb.SelectedDate;
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(_backPath == 0)
            {
                NavigationSystem.MainFrame.Content = new ReservationControl();
            }
            else
            {
                NavigationSystem.MainFrame.Content = new DataControl();
            }
        }

        private void loadData()
        {
            try
            {
                Db.Events.Load();
                Db.Rooms.Load();
                Db.Bookings.Load();

                EventCb.ItemsSource = Db.Events.ToList();

                if (_id != -1)
                {
                    Db.Events.Load();
                    Db.Rooms.Load();
                    Db.Bookings.Load();

                    booking = Db.Bookings.Where(el => el.Id == _id).First();
                    DataStartCmb.SelectedDate = DateTime.Parse(booking.DataStart);
                    DataEndCmb.SelectedDate = DateTime.Parse(booking.DataEnd);
                    DataCreationCmb.SelectedDate = DateTime.Parse(booking.DataCreation);
                    TimeStartTp.SelectedTime = TimeSpan.Parse(booking.TimeStart);
                    TimeEndTp.SelectedTime = TimeSpan.Parse(booking.TimeEnd);

                    RoomCb.SelectedIndex = 0;
                    EventCb.SelectedIndex = 0;
                }
                else
                {
                    booking = new Booking();
                }
                BookingGrid.DataContext = booking;
            }
            catch
            {

            }
        }

        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                booking.DataStart = DataStartCmb.SelectedDate.Value.ToString("d");
                booking.DataEnd = DataEndCmb.SelectedDate.Value.ToString("d");
                booking.DataCreation = DateTime.Now.ToString("d");
                booking.TimeStart = TimeStartTp.SelectedTime.Value.ToString(@"hh\:mm");
                booking.TimeEnd = TimeEndTp.SelectedTime.Value.ToString(@"hh\:mm");

                if (_id == -1)
                {
                    Db.Bookings.Add(booking);

                    Helper.ShowInfo("Вы успешно забронировали место!");
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
