using System.Collections.Generic;
using NUnit.Framework;
using DataModelsLib;
namespace Tests
{
    public class Tests
    {

        [Test]
        public void TestPatient()
        {
            Patient p = new Patient();
            p.PatientId = "TRJIW431";
            p.PulseRate = 75;
            p.Spo2 = 96;
            p.Temperature = 98.6;
            p.BedNo = 4;
            Assert.AreEqual( 98.6,p.Temperature);
            Assert.AreEqual( 96,p.Spo2);
            Assert.AreEqual( 75,p.PulseRate);
            Assert.AreEqual( "TRJIW431",p.PatientId);
            Assert.AreEqual( 4,p.BedNo);

        }

        [Test]
        public void TestICU()
        {
            Icu icu = new Icu();
            icu.NoOfBeds = 3;
            Patient p = new Patient();
            icu.ICUPatient = p;
            Dictionary<int, bool> bedOccupancy = new Dictionary<int, bool>();
            bedOccupancy.Add(1, true);
            bedOccupancy.Add(3, true);
            bedOccupancy.Add(9, false);
            Icu.BedOccupancy = bedOccupancy;
            Assert.AreEqual(3, icu.NoOfBeds);
            Assert.AreEqual(icu.ICUPatient, p);
            Assert.AreEqual(Icu.BedOccupancy, bedOccupancy);
        }
    }
}
