using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges
{
    public partial class EditTeacher : UserControl
    {
        private long _id = -1;
        private Teacher _teacher;
        public EditTeacher(long id)
        {
            InitializeComponent();
            OkBtn.Click += OkBtn_Click;
            BackBtn.Click += BackBtn_Click;
            _id = id;
            loadData();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RefreshAll();
            NavigationSystem.MainFrame.Content = new TeacherControl();
        }

        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    Db.Teachers.Add(_teacher);

                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new TeacherControl();
            }
            catch { }
        }

        private void loadData()
        {
            try
            {
                Db.Teachers.Load();

                if (_id != -1)
                {
                    _teacher = Db.Teachers.Where(el => el.Id == _id).First();
                }
                else
                {
                    _teacher = new Teacher();
                }
                TeacherGrid.DataContext = _teacher;
            }
            catch { }
        }
    }
}
