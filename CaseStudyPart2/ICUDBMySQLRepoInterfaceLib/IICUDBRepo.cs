using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModelsLib;
namespace ICUDBMySQLRepoInterfaceLib
{
    public interface IICUDBRepo
    {
       
        void ReadRecord(ref string id, ref int spo2, ref int pulse, ref double temp);
        void AdmitPatient(string id,int bedno);
        void DischargePatient(string id,int bedno);
    }
}
