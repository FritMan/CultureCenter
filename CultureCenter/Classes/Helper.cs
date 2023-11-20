using Avalonia.Controls;
using CultureCenter.data;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureCenter.Classes
{   
    public static class Helper
    {
        public static string PartName = "";
        public static CultureDataBaseContext Db = new CultureDataBaseContext();

        public static void ShowError(string message)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка", message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Error,
                    WindowStartupLocation.CenterScreen).ShowAsync();
        }
        public static void ShowInfo(string message)
        {
            MessageBoxManager.GetMessageBoxStandard("Информация", message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok,
                    MsBox.Avalonia.Enums.Icon.Info,
                    WindowStartupLocation.CenterScreen).ShowAsync();
        }

        public async static Task<MsBox.Avalonia.Enums.ButtonResult> ShowQuestion(string message) 
        {
            return await MessageBoxManager.GetMessageBoxStandard("Вопрос", message,
                    MsBox.Avalonia.Enums.ButtonEnum.YesNo,
                    MsBox.Avalonia.Enums.Icon.Question,
                    WindowStartupLocation.CenterScreen).ShowAsync();
        }

        public static void RefreshAll()
        {
            foreach (var item in Db.ChangeTracker.Entries())
            {
                item.Reload();
            };
        }
    }


}
