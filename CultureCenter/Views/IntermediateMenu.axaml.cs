using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
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
            ApplicationsBtn.Click += ApplicationsBtn_Click;
            TypeOfWorkBtn.Click += TypeOfWorkBtn_Click;
            PremisesBtn.Click += PremisesBtn_Click;
            StatusesBtn.Click += StatusesBtn_Click;
            DesktopBtn.Click += DesktopBtn_Click;
            ReservationBtn.Click += ReservationBtn_Click;
            BookingServeiseBtn.Click += BookingServeiseBtn_Click;

        }

        private void BookingServeiseBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new BookingServeise();
        }

        private void ReservationBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ReservationControl();
        }

        private void DesktopBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new Desktop();
        }

        private void StatusesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new StatusControl();
        }

        private void PremisesBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new PremisesControl(0);
        }

        private void TypeOfWorkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new TypeOfWork();
        }

        private void ApplicationsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ApplicationControl();
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
