using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Pages;
using System;
using static CultureCenter.Classes.Helper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CultureCenter.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        EnlightenmentBtn.Click += EnlightenmentBtn_Click;
        EntertainmentsBtn.Click += EntertainmentsBtn_Click;
        EducationBtn.Click += EducationBtn_Click;
        ApplicationsBtn.Click += ApplicationsBtn_Click;
        PremisesBtn.Click += PremisesBtn_Click;
        TypeOfWorkBtn.Click += TypeOfWorkBtn_Click;
        DesktopBtn.Click += DesktopBtn_Click;
        StatusesBtn.Click += StatusesBtn_Click;
    }

    private void StatusesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new StatusControl();
    }

    private void DesktopBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new Desktop();
    }

    private void TypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new TypeOfWork();
    }

    private void PremisesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new PremisesControl();
    }

    private void ApplicationsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new ApplicationControl();
    }

    private void EducationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new ControlEducation();
    }

    private void EntertainmentsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartName = "Развлекательные";
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

    private void EnlightenmentBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartName = "Просветительские";
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

}
