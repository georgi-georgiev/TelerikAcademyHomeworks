using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleWCFService
{
    public class Service : IService
    {
        public string GetDayInBulgarian(DateTime value)
        {
            string dayInBulgarian;
            
            switch(value.DayOfWeek.ToString())
            {
                case "Monday":
                    dayInBulgarian = "Понеделник";
                    break;
                case "Tuesday":
                    dayInBulgarian = "Вторник";
                    break;
                case "Wednesday":
                    dayInBulgarian = "Сряда";
                    break;
                case "Thursday":
                    dayInBulgarian = "Четвъртък";
                    break;
                case "Friday":
                    dayInBulgarian = "Петък";
                    break;
                case "Saturday":
                    dayInBulgarian = "Събота";
                    break;
                case "Sunday":
                    dayInBulgarian = "Неделя";
                    break;
                default:
                    throw new ArgumentException("Invalid day of the week: " + value.DayOfWeek.ToString());

            }

            return dayInBulgarian;
        }
    }
}
