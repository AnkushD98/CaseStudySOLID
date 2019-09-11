using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
namespace PulseCheckerInteraceLib
{
    public interface IPulseChecker
    {
        Vitals.Pulse CheckPulse(int pulse);
    }
}
