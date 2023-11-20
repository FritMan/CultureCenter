using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CultureCenter.Pages
{
    public partial class ControlEducation : UserControl
    {
        public ControlEducation()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MainView();
        }
    }
}
