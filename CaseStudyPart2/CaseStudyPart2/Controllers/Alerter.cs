using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;
using DataModelsLib;
using PulseCheckerInteraceLib;
using Spo2CheckerInterfaceLib;
using TempCheckerInterfaceLib;
using PulseCheckerLib;
using Spo2CheckerLib;
using TemperatureCheckerLib;
namespace CaseStudyPart2.Controllers
{
    public class Alerter:ApiController
    {
        ISpo2Checker _spo2Checker;
        IPulseChecker _pulseChecker;
        ITempChecker _tempChecker;
        ICUDBMySQLRepoInterfaceLib.IICUDBRepo _db;
        UnityContainer _con = new UnityContainer();
        public Alerter()
        {
            _con.RegisterType<ISpo2Checker, Spo2Checker>();
            _con.RegisterType<IPulseChecker, PulseChecker>();
            _con.RegisterType<ITempChecker, TempChecker>();
            _con.RegisterType<ICUDBMySQLRepoInterfaceLib.IICUDBRepo, ICUDBMySQLRepository.ICUDBMySQLRepo>();
        }
        public static Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
        public static int cnt = 1;

        [Route("api/lol")]
        [HttpGet]
        public string getlo()
        {
            return "lol";
        }
        [Route("api/AlertGenerator/{id}")]
        [HttpGet]
        public List<string> GenerateAlert(string id)
        {
            _pulseChecker = _con.Resolve<IPulseChecker>();
            _spo2Checker = _con.Resolve<ISpo2Checker>();
            _tempChecker = _con.Resolve<ITempChecker>();
            _db = _con.Resolve<ICUDBMySQLRepoInterfaceLib.IICUDBRepo>();
            List<string> localList = new List<string>();
            if (res.ContainsKey(id))
            {
                foreach (var str in res[id])
                {
                    localList.Add(str);
                }
            }

            localList.Add("========ALERT NUMBER:" + cnt++ + "=======");
            localList.Add("\n");
            int spo2=0, pulseRate=0;string patientId="null";double temp=0.0;
            _db.ReadRecord(ref patientId,ref spo2,ref pulseRate,ref temp);

            Dictionary<int, string> spo2Dictionary = new Dictionary<int, string>();
            spo2Dictionary.Add(1, "Normal healthy individual");
            spo2Dictionary.Add(2, "Clinically acceptable but low. Patient may be a smoker or be unhealthy");
            spo2Dictionary.Add(3, "Hypoxemia. Unhealthy and unsafe level");
            spo2Dictionary.Add(4, "Extreme lack of oxygen, ischemic disease may occur");
            spo2Dictionary.Add(5, "Invalid Input");

            Dictionary<int, string> pulseDictionary = new Dictionary<int, string>();
            pulseDictionary.Add(1, "Below healthy resting heart rate");
            pulseDictionary.Add(2, "Resting heartrate for sleeping");
            pulseDictionary.Add(3, "Healthy adult resting heart rate");
            pulseDictionary.Add(4, "Acceptable if measured during exercise. Not acceptable if resting heart rate");
            pulseDictionary.Add(5, "Abnormally high heart rate");
            pulseDictionary.Add(6, "Invalid Input");

            Dictionary<int, string> tempDictionary = new Dictionary<int, string>();
            tempDictionary.Add(1, "Medical Emergency");
            tempDictionary.Add(2, "Sleepiness, Depressed, Confused");
            tempDictionary.Add(3, "Loss of moment of fingers, blueness and confusion");
            tempDictionary.Add(4, "Hypothermia");
            tempDictionary.Add(5, "Feeling cold");
            tempDictionary.Add(6, "Normal body temperature");
            tempDictionary.Add(7, "Unhealthy and high fever");
            tempDictionary.Add(8, "Invalid Input");

            localList.Add(spo2Dictionary[(int)_spo2Checker.CheckSpo2(spo2)] + "\n");
            localList.Add(pulseDictionary[(int)_pulseChecker.CheckPulse(pulseRate)] + "\n");
            localList.Add(tempDictionary[(int)_tempChecker.CheckTemp(temp)]);
            res[id] = localList;
            return localList;
        }

        [Route("api/AlarmShutter/{id}")]
        [HttpGet]
        public void TurnOffAlarm(string id)
        {
            res[id].Clear();
        }
    }
}
