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
            Assert.AreEqual( p.Temperature,98.6);
            Assert.AreEqual( p.Spo2,96);
            Assert.AreEqual( p.PulseRate,75);
            Assert.AreEqual( p.PatientId,"TRJIW431");
            Assert.AreEqual(p.BedNo,4);

        }

        [Test]
        public void TestICU()
        {
            ICU icu= new ICU();
            icu.NoOfBeds = 3;
            Patient p= new Patient();
            icu.ICUPatient = p;
            Dictionary<int,bool> bedOccupancy=new Dictionary<int, bool>();
            bedOccupancy.Add(1,true);
            bedOccupancy.Add(3,true);
            bedOccupancy.Add(9,false);
            ICU.BedOccupancy = bedOccupancy;
            Assert.AreEqual(icu.NoOfBeds, 3);
            Assert.AreEqual(icu.ICUPatient,p);
            Assert.AreEqual(ICU.BedOccupancy,bedOccupancy);
        }
    }
}