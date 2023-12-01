using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Linq;
using static CultureCenter.Classes.Helper;
namespace CultureCenter.Pages;

public partial class PremisesControl : UserControl
{
    private int _backPath = 0;
    public PremisesControl(int backPath)
    {
        InitializeComponent();
        _backPath = backPath;
        BackBtn.Click += BackBtn_Click;
        AddPremisesBtn.Click += AddPremisesBtn_Click; ;
        EditPremisesBtn.Click += EditPremisesBtn_Click;
        DeletePremisesBtn.Click += DeletePremisesBtn_Click;
        SearchTB.TextChanged += SearchTB_TextChanged;
        LoadData();
    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
    {
        LoadData();
    }

    private void AddPremisesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new EditPremises(-1, _backPath);
    }

    private void EditPremisesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedRoom = PremisesDG.SelectedItem as Room;
        if (selectedRoom != null)
        {
            NavigationSystem.MainFrame.Content = new EditPremises(selectedRoom.Id, _backPath);
        }
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if(_backPath == 0)
        {
            NavigationSystem.MainFrame.Content = new IntermediateMenu();
        }
        else
        {
            NavigationSystem.MainFrame.Content = new ControlEducation();
        }
    }

    private async void DeletePremisesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            var selectedRoom = PremisesDG.SelectedItem as Room;
            if (selectedRoom != null)
            {
                if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                {
                    Db.Rooms.Remove(selectedRoom);
                    Db.SaveChanges();
                    NavigationSystem.MainFrame.Content = new PremisesControl(_backPath);
                }
            }
        }
        catch { }
    }

    private void LoadData()
    {
        Db.Rooms.Load();
        if (string.IsNullOrEmpty(SearchTB.Text))
        {
            PremisesDG.ItemsSource = Db.Rooms;
        }
        else
        {
            PremisesDG.ItemsSource = Db.Rooms.Where(el => el.Name.Contains(SearchTB.Text));
        }
    }
}

