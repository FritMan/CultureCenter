using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
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
        EditTypeOfWorkBtn.Click += EditTypeOfWorkBtn_Click; ;
        EditTypeOfWorkBtn.Click += EditTypeOfWorkBtn_Click;
        EditTypeOfWorkBtn.Click += EditTypeOfWorkBtn_Click;
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
        NavigationSystem.MainFrame.Content = new EditPremises(-1);
    }

    private void EditTypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedRoom = PremisesDG.SelectedItem as Room;
        if (selectedRoom != null)
        {
            NavigationSystem.MainFrame.Content = new EditPremises(selectedRoom.Id);
        }
    }

    private async void DeleteTypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedRoom = PremisesDG.SelectedItem as Room;
        if (selectedRoom != null)
        {
            if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
            {
                Db.Rooms.Remove(selectedRoom);
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new EditPremises();
            }
        }
    }

    private void LoadData()
    {
        Db.WorkTypes.Load();
        if (string.IsNullOrEmpty(SearchTB.Text))
        {
            PremisesDG.ItemsSource = Db.WorkTypes;
        }
        else
        {
            PremisesDG.ItemsSource = Db.WorkTypes.Where(el => el.Name.Contains(SearchTB.Text));
        }
    }
}