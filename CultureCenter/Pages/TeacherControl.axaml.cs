using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class TeacherControl : UserControl
    {
        public TeacherControl()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
            SearchTB.TextChanged += SearchTB_TextChanged;
            AddTeachersBtn.Click += AddTeachersBtn_Click;
            EditTeachersBtn.Click += EditTeachersBtn_Click;
            DeleteTeachersBtn.Click += DeleteTeachersBtn_Click;
            LoadData();
        }

        private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private async void DeleteTeachersBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                var selectedTeacher = TeachersDG.SelectedItem as Teacher;
                if (selectedTeacher != null)
                {
                    if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                    {
                        Db.Teachers.Remove(selectedTeacher);
                        Db.SaveChanges();
                        NavigationSystem.MainFrame.Content = new TeacherControl();
                    }
                }
                else
                {
                    Helper.ShowInfo("Выберите преподавателя");
                    return;
                }
            }
            catch
            { }
        }

        private void EditTeachersBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedTeacher = TeachersDG.SelectedItem as Teacher;
            if (selectedTeacher != null)
            {
                NavigationSystem.MainFrame.Content = new EditTeacher(selectedTeacher.Id);
            }
        }

        private void AddTeachersBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new EditTeacher(-1);
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ControlEducation();
        }

        private void LoadData()
        {
            Db.Teachers.Load();
            if (string.IsNullOrEmpty(SearchTB.Text))
            {
                TeachersDG.ItemsSource = Db.Teachers;
            }
            else
            {
                TeachersDG.ItemsSource = Db.Teachers.Where(el => el.Name.Contains(SearchTB.Text));
            }
        }
    }
}
