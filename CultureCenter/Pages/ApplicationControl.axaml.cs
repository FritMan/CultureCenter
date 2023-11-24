using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CultureCenter.Classes;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CultureCenter.Pages;

public partial class ApplicationControl : UserControl
{
    public ApplicationControl()
    {
        InitializeComponent();
        BackBtn.Click += BackBtn_Click;
    }

    private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NavigationSystem.MainFrame.Content = new MainView();
    }
}