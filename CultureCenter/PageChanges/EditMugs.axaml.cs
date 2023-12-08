using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Cryptography;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges
{
    public partial class EditMugs : UserControl
    {
        private long _id;
        private Mug Mug;

        public EditMugs(long Id)
        {
            InitializeComponent();
            _id = Id;
            
            BackBtn.Click += BackBtn_Click;
            OkBtn.Click += OkBtn_Click;

            loadData();
            DaysCb.SelectionChanged += DaysCb_SelectionChanged;
        }

        private void DaysCb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            DayId2L.IsVisible = false;
            DayId2Cb.IsVisible = false;
            DayId3L.IsVisible = false;
            DayId3Cb.IsVisible = false;
            var mug = MugGrid.DataContext as Mug;

            if (DaysCb.SelectedIndex == 0)
            {
                mug.DayId2Navigation = null;
                mug.DayId3Navigation = null;
            }

            if (DaysCb.SelectedIndex == 1) 
            {
                DayId2L.IsVisible = true;
                DayId2Cb.IsVisible = true;
                mug.DayId3Navigation = null;
            }

            if (DaysCb.SelectedIndex == 2)
            {
                DayId2L.IsVisible = true;
                DayId2Cb.IsVisible = true;
                DayId3L.IsVisible = true;
                DayId3Cb.IsVisible = true;
            }
        }

        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                Mug.DateStartOfWork = DateStartOfWorkCmb.SelectedDate.Value.ToString("d");
                Mug.TimeStart = TimeStartTp.SelectedTime.Value.ToString(@"hh\:mm");
                Mug.TimeEnd = TimeEndTp.SelectedTime.Value.ToString(@"hh\:mm");

                if (_id == -1)
                {
                    Db.Mugs.Add(Mug);
                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new MugsControl();

            }
            catch (Exception ex)
            {

            }
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new MugsControl();
        }

        private void loadData()
        {
            try
            {
                Db.DaysOfWeeks.Load();
                Db.Teachers.Load();
                Db.Rooms.Load();
                Db.MugsTypes.Load();

                MugsTypesCb.ItemsSource = Db.MugsTypes.ToList();
                TeacherCb.ItemsSource = Db.Teachers.ToList();
                RoomCb.ItemsSource = Db.Rooms.ToList();
                DayId1Cb.ItemsSource = Db.DaysOfWeeks.ToList();
                DayId2Cb.ItemsSource = Db.DaysOfWeeks.ToList();
                DayId3Cb.ItemsSource = Db.DaysOfWeeks.ToList();


                if (_id != -1)
                {
                    Db.Teachers.Load();
                    Db.Rooms.Load();
                    Db.MugsTypes.Load();

                    Mug = Db.Mugs.Where(el => el.Id == _id).First();
                    DateStartOfWorkCmb.SelectedDate = DateTime.Parse(Mug.DateStartOfWork);
                    TimeStartTp.SelectedTime = TimeSpan.Parse(Mug.TimeStart);
                    TimeEndTp.SelectedTime = TimeSpan.Parse(Mug.TimeEnd);

                    
                }
                else
                {
                    Mug = new Mug();
                    RoomCb.SelectedIndex = 0;
                    TeacherCb.SelectedIndex = 0;
                    DayId1Cb.SelectedIndex = 0;
                }
                MugGrid.DataContext = Mug;
            }
            catch
            {
            }
        }
    }
}
