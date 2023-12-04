using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.PageChanges;
using CultureCenter.Views;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{
    public partial class MugsTypes : UserControl
    {
        public MugsTypes()
        {
            InitializeComponent();
            BackBtn.Click += BackBtn_Click;
            AddMugsTypeBtn.Click += AddMugsTypeBtn_Click; ;
            EditMugsTypeBtn.Click += EditMugsTypeBtn_Click;
            DeleteMugsTypeBtn.Click += DeleteMugsTypeBtn_Click;
            SearchTB.TextChanged += SearchTB_TextChanged;
            LoadData();
        }

        private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ControlEducation();
        }

        private void AddMugsTypeBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new PageChanges.MugsTypesEdit(-1);
        }

        private void EditMugsTypeBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var selectedTypes = MugsTypesDG.SelectedItem as MugsType;
            if (selectedTypes != null)
            {
                NavigationSystem.MainFrame.Content = new MugsTypesEdit(selectedTypes.Id);
            }
        }

        private async void DeleteMugsTypeBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                var selectedTypes = MugsTypesDG.SelectedItem as MugsType;
                if (selectedTypes != null)
                {
                    if (await ShowQuestion("Вы уверены?") == MsBox.Avalonia.Enums.ButtonResult.Yes)
                    {
                        Db.MugsTypes.Remove(selectedTypes);
                        Db.SaveChanges();
                        NavigationSystem.MainFrame.Content = new MugsTypes();
                    }
                }
            }
            catch { }
        }

        private void LoadData()
        {
            Db.MugsTypes.Load();
            if (string.IsNullOrEmpty(SearchTB.Text))
            {
                MugsTypesDG.ItemsSource = Db.MugsTypes;
            }
            else
            {
                MugsTypesDG.ItemsSource = Db.MugsTypes.Where(el => el.Name.Contains(SearchTB.Text));
            }
        }
    }
}
