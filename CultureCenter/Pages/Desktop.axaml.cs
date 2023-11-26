using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages;

public partial class Desktop : UserControl
{
    private WorkOrder WorkOrder
    public Desktop()
    {
        InitializeComponent();
        LoadData();
        BackBtn.Click += BackBtn_Click;
        DesktopDG.LoadingRow += DesktopDG_LoadingRow;
        SearchTB.TextChanged += SearchTB_TextChanged;

    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void DesktopDG_LoadingRow(object? sender, DataGridRowEventArgs e)
    {
        var data = e.Row.DataContext as WorkOrder;

        if (data.Status.Name == "К выполнению")
        {
            e.Row.Background = new SolidColorBrush(Colors.Pink);
        }
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new MainView();
    }


    private void LoadData()
    {
        Db.WorkOrders.Load();
        Db.WorkTypes.Load();
        Db.Rooms.Load();
        Db.Statuses.Load();
        Db.Events.Load();
        DesktopDG.ItemsSource = null;
        DesktopDG.ItemsSource = Db.WorkOrders.Where(el => el.StatusId == 2);
        if (string.IsNullOrEmpty(SearchTB.Text) && WorkOrder.StatusId == 2)
        {
            DesktopDG.ItemsSource = Db.WorkOrders;
        }
        else
        {
            DesktopDG.ItemsSource = Db.WorkOrders.Where(el => el.WorkTypes.Name.Contains(SearchTB.Text));
        }
    }
}