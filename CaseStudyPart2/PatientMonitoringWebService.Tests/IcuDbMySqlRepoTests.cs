using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ICUDBMySQLRepoInterfaceLib;
using ICUDBMySQLRepository;

namespace PatientMonitoringWebService.Tests
{
    [TestFixture]
    public class IcuDbMySqlRepoTests
    {
        [Test]
        public void TestRead()
        {
            
            IcuDbMySqlRepo obj1 = new IcuDbMySqlRepo();
            string id = "TRJIW431";
            int spo2 = 0, pulse = 0; double temp = 0.0;
            obj1.ReadRecord(ref id, ref spo2, ref pulse, ref temp);
            Assert.AreEqual( 96,spo2);
            Assert.AreEqual( 75,temp);
            Assert.AreEqual( 98,pulse);
        }

        [Test]
        public void TestDischarge()
        {
            IcuDbMySqlRepo obj = new IcuDbMySqlRepo();
            obj.DischargePatient("TRJIW433", 2);
            int spo2 = 0, pulse = 0; double temp = 0.0;
            string id = "TRJIW433";
            Assert.Throws<InvalidOperationException>(
                delegate { obj.ReadRecord(ref id, ref spo2, ref pulse, ref temp); });

        }

        [Test]
        public void AdmitPatient()
        {
            IcuDbMySqlRepo obj = new IcuDbMySqlRepo();
            string id = "TRJIW432";
            int spo2 = 0, pulse = 0; double temp = 0.0;
            obj.AdmitPatient(id, 9);
            obj.ReadRecord(ref id, ref spo2, ref pulse, ref temp);
            Assert.AreEqual( 97,spo2);
            Assert.AreEqual( 76.0,temp);
            Assert.AreEqual( 99,pulse);
        }

    }
}

