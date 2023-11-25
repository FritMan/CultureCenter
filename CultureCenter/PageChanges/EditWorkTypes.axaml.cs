using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges;

public partial class EditWorkTypes : UserControl
{
    public EditWorkTypes()
    {
        InitializeComponent();
        loadData();
    }

    private long _id;
    private WorkType WorkType;

    public EditWorkTypes(long id)
    {
        InitializeComponent();
        _id = id;
        OkBtn.Click += OkBtn_Click;
        BackBtn.Click += BackBtn_Click;
        loadData();
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        RefreshAll();
        NavigationSystem.MainFrame.Content = new TypeOfWork();
    }
    private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            if (_id == -1)
            {
                Db.WorkTypes.Add(WorkType);
            }
            Db.SaveChanges();
            NavigationSystem.MainFrame.Content = new TypeOfWork();
        }
        catch (System.Exception ex)
        {

        }
    }

    private void loadData()
    {
        try
        {
            Db.WorkTypes.Load();

            if (_id != -1)
            {
                Db.WorkTypes.Load();
                WorkType = Db.WorkTypes.Where(el => el.Id == _id).First();
            }
            else
            {
                WorkType = new WorkType();
            }
            WorkTypesGrid.DataContext = WorkType;
        }
        catch (System.Exception)
        {

        }
    }
}