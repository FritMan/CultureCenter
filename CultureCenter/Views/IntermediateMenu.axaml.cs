using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Views
{
    public partial class IntermediateMenu : UserControl
    {
        public IntermediateMenu()
        {
            InitializeComponent();
            Types.Content = Helper.PartName;
            EventBtn.Click += EventBtn_Click;
            TypesEventBtn.Click += TypesEventBtn_Click;
            BackBtn.Click += BackBtn_Click;
        }


        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MainView();
        }

        private void TypesEventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            NavigationSystem.MainFrame.Content = new ControlTypes();
        }

        private void EventBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new DataControl();
        }


    }
}
