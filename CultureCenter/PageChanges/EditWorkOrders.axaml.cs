using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges;

public partial class EditWorkOrders : UserControl
{
    private long _id;
    private WorkOrder WorkOrder;
        
    public EditWorkOrders()
    {
        InitializeComponent();
        LoadData();
    }

    public EditWorkOrders(long id)
    {
        InitializeComponent();
        _id = id;
        OkBtn.Click += OkBtn_Click;
        BackBtn.Click += BackBtn_Click;
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            Db.TypesOfEvents.Load();
            Db.Events.Load();
            Db.Rooms.Load();
            Db.WorkOrders.Load();
            Db.Statuses.Load();
            Db.WorkTypes.Load();

            EventCb.ItemsSource = Db.Events.ToList();
            RoomCb.ItemsSource = Db.Rooms.ToList();
            StatusCb.ItemsSource = Db.Statuses.ToList();
            WorkTypesCb.ItemsSource = Db.WorkTypes.ToList();


            if (_id != -1)
            {
                Db.TypesOfEvents.Load();
                Db.Events.Load();
                Db.Rooms.Load();
                Db.WorkOrders.Load();
                Db.Statuses.Load();
                Db.WorkTypes.Load();

                WorkOrder = Db.WorkOrders.Where(el => el.Id == _id).First();
                DateStartCmb.SelectedDate = DateTime.Parse(WorkOrder.DateStart);
                DateEndCmb.SelectedDate = DateTime.Parse(WorkOrder.DateEnd);
                RoomCb.SelectedIndex = 0;
                StatusCb.SelectedIndex = 0;
                WorkTypesCb.SelectedIndex = 0;
                EventCb.SelectedIndex = 0;
            }
            else
            {
                WorkOrder = new WorkOrder();
            }

            WorkOrderGrid.DataContext = WorkOrder;
        }
        catch { }
    }
    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RefreshAll();
        NavigationSystem.MainFrame.Content = new ApplicationControl();
    }

    private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            WorkOrder.DateStart = DateStartCmb.SelectedDate.Value.ToString("d");
            WorkOrder.DateEnd = DateEndCmb.SelectedDate.Value.ToString("d");

            if (_id == -1)
            {
                Db.WorkOrders.Add(WorkOrder);
            }
            Db.SaveChanges();
            NavigationSystem.MainFrame.Content = new ApplicationControl();
        }
        catch(Exception ex)
        {
            
        }
    }

}