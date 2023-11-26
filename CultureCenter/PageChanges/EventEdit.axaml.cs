using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static CultureCenter.Classes.Helper;
namespace CultureCenter.Pages
{
    public partial class EventEdit : UserControl
    {
        public EventEdit()
        {
            InitializeComponent();
            loadData();
        }

        private long _id;
        private Event Event;

        public EventEdit(long id)
        {
            InitializeComponent();
            _id = id;
            OkBtn.Click += OkBtn_Click;
            BackBtn.Click += BackBtn_Click;
            loadData();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RefreshAll();
            NavigationSystem.MainFrame.Content = new DataControl();
        }
        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                Event.EventDate = EventDateCmb.SelectedDate.Value.ToString("d");
                if (_id == -1)
                {
                    Db.Events.Add(Event);
                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new DataControl();
            }
            catch{ }
        }

        private void loadData()
        {
            try
            {
                Db.TypesOfEvents.Load();
                NameCb.ItemsSource = Db.TypesOfEvents.ToList();;

                if (_id != -1)
                {
                    Db.Events.Load();
                    Event = Db.Events.Where(el => el.Id == _id).First();
                    EventDateCmb.SelectedDate = System.DateTime.Parse(Event.EventDate);
                }
                else
                {
                    Event= new Event();
                }
                EventGrid.DataContext = Event;
            }
            catch
            {

            }
        }
    }
}
