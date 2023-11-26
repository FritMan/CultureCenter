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
        SearchTB.TextChanged += SearchTB_TextChanged;
        ApplicationDG.LoadingRow += ApplicationDG_LoadingRow;
        AddApplicationBtn.Click += AddApplicationBtn_Click;
    }

    private void AddApplicationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new EditWorkOrderes();
    }

    private void ApplicationDG_LoadingRow(object? sender, DataGridRowEventArgs e)
    {
        Db.Statuses.Load();
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

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        Db.TypesOfEvents.Load();
        Db.WorkOrders.Load();
        Db.Events.Load();
        Db.WorkTypes.Load();
        Db.Rooms.Load();
        Db.Statuses.Load();
        if(string.IsNullOrEmpty(SearchTB.Text))
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