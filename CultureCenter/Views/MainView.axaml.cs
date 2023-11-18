using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Pages;
using System;

namespace CultureCenter.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        EnlightenmentBtn.Click += EnlightenmentBtn_Click;
        EntertainmentsBtn.Click += EntertainmentsBtn_Click;
    }

    private void EntertainmentsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }

    private void EnlightenmentBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new IntermediateMenu();
    }
}
