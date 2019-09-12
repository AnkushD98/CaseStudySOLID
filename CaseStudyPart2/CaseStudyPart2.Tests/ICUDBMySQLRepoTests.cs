using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using ICUDBMySQLRepoInterfaceLib;
using ICUDBMySQLRepository;

namespace CaseStudyPart2.Tests
{
    [TestFixture]
    public class ICUDBMySQLRepoTests
    {
        [Test]
        public void TestRead()
        {
            Mock<IIcuDbRepo> mockWrapper=new Mock<IIcuDbRepo>();

            IIcuDbRepo obj = mockWrapper.Object;
            IcuDbMySqlRepo obj1=new IcuDbMySqlRepo();
            string id="TRJIW431";
            int spo2=0, pulse=0;  double temp=0.0;
            obj1.ReadRecord(ref id,ref spo2,ref pulse,ref temp);
            Assert.AreEqual(spo2,96);
            Assert.AreEqual(temp,75);
            Assert.AreEqual(pulse,98);
        }

        [Test]
        public void TestDischarge()
        {
            IcuDbMySqlRepo obj=new IcuDbMySqlRepo();
            obj.DischargePatient("TRJIW433",2);
            int spo2 = 0, pulse = 0; double temp = 0.0;
            string id = "TRJIW433";
            
            System.InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
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
            Assert.AreEqual(spo2,97);
            Assert.AreEqual(temp,76.0);
            Assert.AreEqual(pulse,99);
        }

    }
}
