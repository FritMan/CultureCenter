using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Pages;
using System;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        EnlightenmentBtn.Click += EnlightenmentBtn_Click;
        EntertainmentsBtn.Click += EntertainmentsBtn_Click;
        EducationBtn.Click += EducationBtn_Click;
    }

    private void EducationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new ControlEducation();
    }

    private void EntertainmentsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartName = "Развлечения";
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

    private void EnlightenmentBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartName = "Просвещение";
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

}
