using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages;

public partial class BookingServeise : UserControl
{
    public BookingServeise()
    {
        InitializeComponent();
        DataCreationCmb.SelectedDate = DateTime.Now;
        loadRooms();
        DataCreationCmb.SelectedDateChanged += DataCreationCmb_SelectedDateChanged;
        BookBtn.Click += BookBtn_Click;
        BackBtn.Click += BackBtn_Click;
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

    private void BookBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new EditBooking(-1, 2, 0, (RoomCb.SelectedItem as Room).Id);
    }

    private void DataCreationCmb_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        loadRooms();
    }

    private void loadRooms()
    {
        try
        {
            var allRooms = Db.Rooms.ToList();
            List<Room> reservedRooms = new List<Room>();

            foreach (var el in Db.Bookings)
            {
                if (DateTime.Parse(el.DataStart).Date <= DataCreationCmb.SelectedDate.Value.Date &&
                    DateTime.Parse(el.DataEnd).Date >= DataCreationCmb.SelectedDate.Value.Date)
                {
                    reservedRooms.Add(el.Room);
                }
            }
            reservedRooms = reservedRooms.Distinct().ToList();
            var emptyRooms = allRooms.Except(reservedRooms);
            RoomCb.ItemsSource = emptyRooms;
            RoomCb.SelectedIndex = 0;
        }
        catch { }
    }
}