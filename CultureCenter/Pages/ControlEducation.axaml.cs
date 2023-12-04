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
            MugsTypesBtn.Click += MugsTypesBtn_Click;
            DaysBtn.Click += DaysBtn_Click;
        }

        private void DaysBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new Days();
        }

        private void MugsTypesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MugsTypes();
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
