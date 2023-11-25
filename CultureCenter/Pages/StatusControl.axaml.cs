using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages;

public partial class StatusControl : UserControl
{
    public StatusControl()
    {
        InitializeComponent();
        LoadData();
        BackBtn.Click += BackBtn_Click;
        SearchTB.TextChanged += SearchTB_TextChanged;
        StatusesDG.LoadingRow += StatusesDG_LoadingRow;
    }

    private void StatusesDG_LoadingRow(object? sender, DataGridRowEventArgs e)
    {
        var data = e.Row.DataContext as Status;

        if (data.Name == "Выполнена")
        {
            e.Row.Background = new SolidColorBrush(Colors.Gray);
        }
        if (data.Name == "К выполнению")
        {
            e.Row.Background = new SolidColorBrush(Colors.Pink);
        }
    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new MainView();
    }

    private void LoadData()
    {
         Db.Statuses.Load();

         if (string.IsNullOrEmpty(SearchTB.Text))
         {
                StatusesDG.ItemsSource = Db.Statuses;
         }
         else
         {
                StatusesDG.ItemsSource = Db.Statuses.Where(el => el.Name.Contains(SearchTB.Text));
         }
    }
}