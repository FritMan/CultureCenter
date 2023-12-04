using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.Views;

namespace CultureCenter.Pages
{
    public partial class ControlEducation : UserControl
    {
        public ControlEducation()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
            EnlightenmentBtn.Click += EnlightenmentBtn_Click;
            TeachersBtn.Click += TeachersBtn_Click;
        }

        private void TeachersBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new TeacherControl();
        }

        private void EnlightenmentBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new PremisesControl(1);
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MainView();
        }
    }
}
