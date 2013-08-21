using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WeekSalary
        {
            get;
            set;
        }

        public int WorkHoursPerDay
        {
            get;
            set;
        }

        public double MoneyPerHour()
        {
            return WeekSalary / (WorkHoursPerDay * 5.0);
        }
    }
}
