using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class Battery
    {
        private string batteryModel;

        public Battery(string batteryModel)
        {
            BatteryModel = batteryModel;
        }

        public Battery(string batteryModel, BatteryType type)
        {
            BatteryModel = batteryModel;
            Type = type;
        }

        public Battery(string batteryModel, ushort hoursIdle, ushort hoursTalk, BatteryType type)
        {
            BatteryModel = batteryModel;
            HoursIdle = hoursIdle;
            HoursTalk = hoursTalk;
            Type = type;
        }

        public string BatteryModel
        {
            get
            {
                return batteryModel;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    batteryModel = value;
                }
                else
                {
                    throw new ArgumentException("The battery model value of the Battery class is null or empty.");
                }
            }
        }

        public ushort? HoursIdle { get; set; }
        public ushort? HoursTalk { get; set; }
        public BatteryType Type { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Battery model: " + BatteryModel + "\n");
            result.Append("Battery hours idle: " + HoursIdle + "\n");
            result.Append("Battery hours talk: " + HoursTalk + "\n");
            result.Append("Battery type: ");
            switch (Type)
            {
                case BatteryType.LiLon: result.Append("LiLon\n"); break;
                case BatteryType.NiCd: result.Append("NiCD\n"); break;
                case BatteryType.NiMH: result.Append("NiMH\n"); break;
                default: result.Append("unknown\n"); break;
            }

            return result.ToString();
        }
    }
}
