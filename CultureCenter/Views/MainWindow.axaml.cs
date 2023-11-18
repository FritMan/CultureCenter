using Avalonia.Controls;
using CultureCenter.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CultureCenter.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        NavigationSystem.MainFrame = MainFrame;
        NavigationSystem.MainFrame.Content = new MainView();
        ExitBtn.Click += ExitBtn_Click;
    }

    private void ExitBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
}
