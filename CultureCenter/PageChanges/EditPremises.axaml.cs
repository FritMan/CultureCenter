using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages;

public partial class EditPremises : UserControl
{
    private long _id;
    private Room room;
    private int _backPath = 0;

    public EditPremises(long id, int backPath)
    {
        InitializeComponent();
        _id = id;
        _backPath = backPath;
        OkBtn.Click += OkBtn_Click;
        BackBtn.Click += BackBtn_Click;
        loadData();
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RefreshAll();
        NavigationSystem.MainFrame.Content = new PremisesControl(_backPath);
    }
    private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            if (_id == -1)
            {
                Db.Rooms.Add(room);
            }
            Db.SaveChanges();
            NavigationSystem.MainFrame.Content = new PremisesControl(_backPath);
        }
        catch { }
    }

    private void loadData()
    {

        try
        {
            Db.Rooms.Load();

            if (_id != -1)
            {
                Db.Rooms.Load();
                room = Db.Rooms.Where(el => el.Id == _id).First();
            }
            else
            {
                room = new Room();
            }
            PremisesGrid.DataContext = room;
        }
        catch{ }
    }
}