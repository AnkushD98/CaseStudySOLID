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
        public Vitals.Temp CheckTemp(double t)
        {
            {
                if (t >= 89 && t <= 91)
                {
                    //Console.WriteLine(" Medical Emergency\n");
                    return Vitals.Temp.Emergency;
                }
                else if (t > 91 && t <= 93)
                {
                    //Console.WriteLine(" Sleepiness, Depressed, Confused\n");
                    return Vitals.Temp.Sleepy;
                }
                else if (t > 93 && t <= 95)
                {
                    //Console.WriteLine(" Loss of moment of fingers, blueness and confusion\n");
                    return Vitals.Temp.Loss;
                }
                else if (t > 95 && t <= 96)
                {
                    //Console.WriteLine(" Hypothermia\n");
                    return Vitals.Temp.Hypothermia;
                }
                else if (t > 96 && t <= 98)
                {
                    //Console.WriteLine(" Feeling cold\n");
                    return Vitals.Temp.Cold;
                }
                else if (t > 98 && t <= 99)
                {
                    //Console.WriteLine(" Normal body temperature\n");
                    return Vitals.Temp.Normal;
                }
                else if (t > 99)
                {
                    //Console.WriteLine(" Unhealthy and high fever\n");
                    return Vitals.Temp.Fever;
                }
                else
                {
                    //Console.WriteLine(" Invalid input\n");
                    return Vitals.Temp.InvalidInput;
                }
            }
        }
    }
}
