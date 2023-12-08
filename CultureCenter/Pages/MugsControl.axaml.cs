using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class MugsControl : UserControl
    {
        public MugsControl()
        {
            InitializeComponent();
            LoadData();
            BackBtn.Click += BackBtn_Click;
            SearchTB.TextChanged += SearchTB_TextChanged;
            DeleteMugsBtn.Click += DeleteMugsBtn_Click;
            EditMugsBtn.Click += EditMugsBtn_Click;
            AddMugsBtn.Click += AddMugsBtn_Click;
        }

        private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void AddMugsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new EditMugs(-1);
        }

        private void EditMugsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedMugs = MugsDG.SelectedItem as Mug;
            if (selectedMugs != null)
            {
                NavigationSystem.MainFrame.Content = new EditMugs(selectedMugs.Id);
            }
        }

        private void LoadData()
        {
            Db.Rooms.Load();
            Db.Teachers.Load();
            Db.MugsTypes.Load();
            Db.DaysOfWeeks.Load();
            if(string.IsNullOrEmpty(SearchTB.Text))
            {
                MugsDG.ItemsSource = Db.Mugs;
            }
            else
            {
                MugsDG.ItemsSource = Db.Mugs.Where(el => el.Name.Contains(SearchTB.Text));
            }
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RefreshAll();
            NavigationSystem.MainFrame.Content = new ControlEducation();
        }

        private async void DeleteMugsBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                var selectedMugs = MugsDG.SelectedItem as Mug;

                if (selectedMugs != null)
                {
                    if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                    {
                        Db.Mugs.Remove(selectedMugs);
                        Db.SaveChanges();
                        NavigationSystem.MainFrame.Content = new MugsControl();
                    }
                }
                else
                {
                    Helper.ShowInfo("Выберите кружок");
                    return;
                }
            }
            catch { }
        }
    }
}
