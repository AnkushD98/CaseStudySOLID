using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsLib
{
    public class Patient
    {
        public string PatientId { get; set; }


        public int Spo2 { get; set; }


        public int PulseRate { get; set; }

        public int BedNo { get; set; }
        public double Temperature { get; set; }
    }
}
