using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static CultureCenter.Classes.Helper;
namespace CultureCenter.Pages;

public partial class TypeOfWork : UserControl
{
    public TypeOfWork()
    {
        InitializeComponent();
        BackBtn.Click += BackBtn_Click;
        AddTypeOfWorkBtn.Click += AddTypeOfWorkBtn_Click; ;
        EditTypeOfWorkBtn.Click += EditTypeOfWorkBtn_Click;
        DeleteTypeOfWorkBtn.Click += DeleteTypeOfWorkBtn_Click;
        SearchTB.TextChanged += SearchTB_TextChanged;
        LoadData();
    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new MainView();
    }

    private void AddTypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new PageChanges.EditWorkTypes(-1);
    }

    private void EditTypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedTypes = TypesOfWorkDG.SelectedItem as WorkType;
        if (selectedTypes != null)
        {
            NavigationSystem.MainFrame.Content = new EditWorkTypes(selectedTypes.Id);
        }
    }

    private async void DeleteTypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedTypes = TypesOfWorkDG.SelectedItem as WorkType;
        if (selectedTypes != null)
        {
            if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
            {
                Db.WorkTypes.Remove(selectedTypes);
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new TypeOfWork();
            }
        }
    }

    private void LoadData()
    {
        Db.WorkTypes.Load();
        if (string.IsNullOrEmpty(SearchTB.Text))
        {
            TypesOfWorkDG.ItemsSource = Db.WorkTypes;
        }
        else
        {
            TypesOfWorkDG.ItemsSource = Db.WorkTypes.Where(el => el.Name.Contains(SearchTB.Text));
        }
    }
}