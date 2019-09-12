using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
namespace Spo2CheckerInterfaceLib
{
    public interface ISpo2Checker
    {
        Vitals.Spo2Level CheckSpo2(int spo2);
    }
}
