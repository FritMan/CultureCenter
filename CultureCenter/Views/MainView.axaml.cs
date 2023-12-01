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
    }

    private void EducationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PartName = "Образование";
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
