using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Cryptography;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.Pages
{   
    public partial class TypesEdit : UserControl
    {
        private long _id;
        private TypesOfEvent Types;
        public TypesEdit()
        {
            InitializeComponent();
            loadData();
        }

        public TypesEdit(long id)
        {
            InitializeComponent();
            _id = id;
            OkBtn.Click += OkBtn_Click;
            BackBtn.Click += BackBtn_Click;
            loadData();
        }

        private void BackBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            NavigationSystem.MainFrame.Content = new ControlTypes();
        }

        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    Db.TypesOfEvents.Add(Types);
                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new ControlTypes();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void loadData()
        {
            try
            {
                Db.TypesOfEvents.Load();

                if (_id != -1)
                {
                    Db.TypesOfEvents.Load();
                    Types = Db.TypesOfEvents.Where(el => el.Id == _id).First();
                }
                else
                {
                    Types = new TypesOfEvent();
                }
                TypesGrid.DataContext = Types;
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
