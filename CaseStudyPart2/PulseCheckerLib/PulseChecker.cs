using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
using PulseCheckerInteraceLib;
namespace PulseCheckerLib
{
    public class PulseChecker : IPulseChecker
    {
        public Vitals.Pulse CheckPulse(int p )
        {
            if (p >= 0 && p < 40)
            {
                return Vitals.Pulse.BelowHealthy;
            }
            else if (p >= 40 && p < 60)
            {
                return Vitals.Pulse.Sleeping;
            }
            else if (p >= 60 && p < 100)
            {
                return Vitals.Pulse.HealthyResting;
            }
            else if (p >= 100 && p <= 220)
            {
                
                return Vitals.Pulse.Excercise;
            }
            else if (p > 220)
            {
                
                return Vitals.Pulse.VeryHigh;
            }

            return Vitals.Pulse.InvalidInput;
        }
    }
}
