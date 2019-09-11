using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spo2CheckerInterfaceLib;
using DataModelsLib;
namespace Spo2CheckerLib
{
    public class Spo2Checker:ISpo2Checker
    {
        public Vitals.Spo2Level CheckSpo2(int s)
        {
            if (s >= 95 && s <= 100)
            {
                
                return Vitals.Spo2Level.NormalHealthy;
            }
            else if (s >= 91 && s < 95)
            {
                
                return Vitals.Spo2Level.ClinicallyAcceptable;
            }
            else if (s >= 70 && s <= 90)
            {
                
                return Vitals.Spo2Level.Hypoxemia;
            }
            else if (s >= 0 && s < 70)
            {
                return Vitals.Spo2Level.LackOfO2;
            }
            else
            {
                
                return Vitals.Spo2Level.InvalidInput;
            }
        }
    }
}
