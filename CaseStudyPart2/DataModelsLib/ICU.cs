using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsLib
{
    public class ICU
    {
        public int NoOfBeds { get; set; }


        public static Dictionary<int, bool> BedOccupancy { get; set; }


        public Patient ICUPatient { get; set; }


        
    }
}
