using Avalonia.Controls;
using CultureCenter.Classes;
using CultureCenter.data;
using CultureCenter.Pages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.PageChanges
{
    public partial class MugsTypesEdit : UserControl
    {

        public MugsTypesEdit()
        {
            InitializeComponent();
            loadData();
        }

        private long _id;
        private MugsType mugsType;

        public MugsTypesEdit(long id)
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
            NavigationSystem.MainFrame.Content = new MugsTypes();
        }
        private void OkBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                if (_id == -1)
                {
                    Db.MugsTypes.Add(mugsType);
                }
                Db.SaveChanges();
                NavigationSystem.MainFrame.Content = new MugsTypes();
            }
            catch
            {

            }
        }

        private void loadData()
        {
            try
            {
                Db.MugsTypes.Load();

                if (_id != -1)
                {
                    Db.MugsTypes.Load();
                    mugsType = Db.MugsTypes.Where(el => el.Id == _id).First();
                }
                else
                {
                    mugsType = new MugsType();
                }
                MugsTypesGrid.DataContext = mugsType;
            }
            catch { }
        }
    }
}   
