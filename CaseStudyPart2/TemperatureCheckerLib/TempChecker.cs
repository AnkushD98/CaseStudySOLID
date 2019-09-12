using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
using TempCheckerInterfaceLib;
namespace TemperatureCheckerLib
{
    public class TempChecker : ITempChecker
    {
        public Vitals.Temp CheckTemp(double temp)
        {
            {
                if (temp>= 89 && temp<= 91)
                {
                    return Vitals.Temp.Emergency;
                }
                else if (temp> 91 && temp<= 93)
                {
                    return Vitals.Temp.Sleepy;
                }
                else if (temp> 93 && temp<= 95)
                {
                    return Vitals.Temp.Loss;
                }
                else if (temp> 95 && temp<= 96)
                {
                    return Vitals.Temp.Hypothermia;
                }
                else if (temp> 96 && temp<= 98)
                {
                    return Vitals.Temp.Cold;
                }
                else if (temp> 98 && temp<= 99)
                {
                    return Vitals.Temp.Normal;
                }
                else if (temp> 99)
                {
                    return Vitals.Temp.Fever;
                }
                else
                {
                    return Vitals.Temp.InvalidInput;
                }
            }
        }
    }
}
