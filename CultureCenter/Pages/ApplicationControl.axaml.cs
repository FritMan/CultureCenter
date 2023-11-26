using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages;

public partial class ApplicationControl : UserControl
{
    public ApplicationControl()
    {
        InitializeComponent();
        LoadData();
        BackBtn.Click += BackBtn_Click;
        ApplicationDG.LoadingRow += ApplicationDG_LoadingRow;
        SearchTB.TextChanged += SearchTB_TextChanged;
        AddApplicationBtn.Click += AddApplicationBtn_Click;
        EditApplicationBtn.Click += EditApplicationBtn_Click;
        DeleteApplicationBtn.Click += DeleteApplicationBtn_Click;
    }

    private async void DeleteApplicationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            var selectedOrder = ApplicationDG.SelectedItem as WorkOrder;
            if (selectedOrder != null)
            {
                if(await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                {
                    Db.WorkOrders.Remove(selectedOrder);
                    Db.SaveChanges();
                    NavigationSystem.MainFrame.Content = new ApplicationControl();
                }
            }
        }
        catch{ }
    }

    private void EditApplicationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedOrder = ApplicationDG.SelectedItem as WorkOrder;
        if (selectedOrder != null)
        {
            NavigationSystem.MainFrame.Content = new EditWorkOrders(selectedOrder.Id);
        }
    }

    private void AddApplicationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new EditWorkOrders(-1);
    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void ApplicationDG_LoadingRow(object? sender, DataGridRowEventArgs e)
    {
        var data = e.Row.DataContext as WorkOrder;

        if (data.Status.Name == "Выполнена")
        {
            e.Row.Background = new SolidColorBrush(Colors.Gray);
        }
        if (data.Status.Name == "К выполнению")
        {
            e.Row.Background = new SolidColorBrush(Colors.Pink);
        }
    }

    private void LoadData()
    {
        Db.TypesOfEvents.Load();
        Db.WorkTypes.Load();
        Db.Rooms.Load();
        Db.Events.Load();
        Db.WorkOrders.Load();
        Db.Statuses.Load();
        if (string.IsNullOrEmpty(SearchTB.Text))
        {
            ApplicationDG.ItemsSource = Db.WorkOrders;
        }
        else
        {
            ApplicationDG.ItemsSource = Db.WorkOrders.Where(el => el.Description.Contains(SearchTB.Text));
        }
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new MainView();
    }
}