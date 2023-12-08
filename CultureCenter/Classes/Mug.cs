using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CultureCenter.Classes.Helper;

namespace CultureCenter.data
{
    public partial class Mug
    {
        public string Days
        {
            get
            {
                Db.DaysOfWeeks.Load();
               
                string result = "";
                if(DayId1Navigation != null)
                {
                    result += DayId1Navigation.Name;
                }
                if (DayId2Navigation != null)
                {
                    result += ", " + DayId2Navigation.Name;
                }
                if (DayId3Navigation != null)
                {
                    result += ", " + DayId3Navigation.Name;
                }

                return result;
            }
        }
    }
}
