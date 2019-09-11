using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsLib
{
    public class Vitals
    {
        public enum Spo2Level
        {
            NormalHealthy = 1,
            ClinicallyAcceptable = 2,
            Hypoxemia = 3,
            LackOfO2 = 4,
            InvalidInput = 5
        }
        public enum Pulse
        {
            BelowHealthy = 1,
            Sleeping = 2,
            HealthyResting = 3,
            Excercise = 4,
            VeryHigh = 5,
            InvalidInput = 6
        }
        public enum Temp
        {
            Emergency = 1,
            Sleepy = 2,
            Loss = 3,
            Hypothermia = 4,
            Cold = 5,
            Normal = 6,
            Fever = 7,
            InvalidInput = 8
        }
    }
}
