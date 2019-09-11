using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICUDBMySQLRepoInterfaceLib;
using DataModelsLib;
using Spo2CheckerInterfaceLib;
using PulseCheckerInteraceLib;
using TempCheckerInterfaceLib;
using Unity;
using Spo2CheckerLib;
using PulseCheckerLib;
using TemperatureCheckerLib;
namespace CaseStudyPart2.Controllers
{
    public class NurseStationController : ApiController
    {
        ISpo2Checker _spo2Checker;
        IPulseChecker _pulseChecker;
        ITempChecker _tempChecker;
        ICUDBMySQLRepoInterfaceLib.IICUDBRepo _db;
        UnityContainer _con = new UnityContainer();
        public NurseStationController()
        {
            _con.RegisterType<ISpo2Checker, Spo2Checker>();
            _con.RegisterType<IPulseChecker, PulseChecker>();
            _con.RegisterType<ITempChecker, TempChecker>();
            _con.RegisterType<ICUDBMySQLRepoInterfaceLib.IICUDBRepo, ICUDBMySQLRepository.ICUDBMySQLRepo>();
        }

        
        [Route("api/PatientAdmitter/{id}/{bedno}")]
        [HttpGet]
        public void AdmitPatient(string id,int bedno)
        {
            _db = _con.Resolve<ICUDBMySQLRepoInterfaceLib.IICUDBRepo>();
            _db.AdmitPatient(id,bedno);
        }
        [Route("api/PatientDischarger/{id}/{bedno}")]
        [HttpGet]
        public void DischargePatient(string id,int bedno)
        { 
            _db = _con.Resolve<ICUDBMySQLRepoInterfaceLib.IICUDBRepo>();
            
            _db.DischargePatient(id,bedno);
        }
        


    }
}
