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
    private WorkOrder workOrder;
    public EditWorkOrders()
    {
        InitializeComponent();
        LoadData();
    }

    public EditWorkOrders(long id)
    {
        InitializeComponent();
        LoadData();
        _id = id;
        OkBtn.Click += OkBtn_Click;
        BackBtn.Click += BackBtn_Click;
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
            workOrder.DateStart = DateStartCmb.SelectedDate.Value.ToString("d");
            workOrder.DateEnd = DateEndCmb.SelectedDate.Value.ToString("d");
            if(_id == -1)
            {
                Db.WorkOrders.Add(workOrder);
            }
            Db.SaveChanges();
            NavigationSystem.MainFrame.Content = new ApplicationControl();
        }
        catch
        {

        }
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

            RoomCb.ItemsSource = Db.Rooms.ToList();
            StatusCb.ItemsSource= Db.Statuses.ToList();
            WorkTypesCb.ItemsSource = Db.WorkTypes.ToList();


            if (_id == -1)
            {
                Db.WorkOrders.Load();
                Db.TypesOfEvents.Load();
                Db.Events.Load();
                Db.Rooms.Load();
                Db.Statuses.Load();
                Db.WorkTypes.Load();

                workOrder = Db.WorkOrders.Where(el => el.Id == _id).First();
                DateStartCmb.SelectedDate = DateTime.Parse(workOrder.DateStart);
                DateEndCmb.SelectedDate = DateTime.Parse(workOrder.DateEnd);
            }
            else
            {
                workOrder = new WorkOrder();
            }
            WorkOrderGrid.DataContext = workOrder;
        }
        catch{ }
    }

}