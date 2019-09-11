using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace CaseStudyPart2.Tests
{
    public class ModelTest
    {
        [Test]
        public void TestPatient()
        {
            Patient p = new Patient();
            p.PatientId = "JW3214";
            p.PulseRate = 72;
            p.Spo2 = 94;
            p.Temperature = 98.6;
            Assert.AreEqual(98.6, p.Temperature);
            Assert.AreEqual(94, p.Spo2);
            Assert.AreEqual(72, p.PulseRate);
            Assert.AreEqual("JW3214", p.PatientId);
        }
        [Test]
        public void TestICU()
        {
            ICU obj=new ICU();
            Patient p = new Patient();
            p.PatientId = "JW3214";
            p.PulseRate = 72;
            p.Spo2 = 94;
            p.Temperature = 98.6;
            p.BedNo = 4;
            obj.ICUPatient = p;
            Assert.AreEqual(98.6, obj.ICUPatient.Temperature);
            Assert.AreEqual(94, obj.ICUPatient.Spo2);
            Assert.AreEqual(72, obj.ICUPatient.PulseRate);
            Assert.AreEqual("JW3214", obj.ICUPatient.PatientId);
            Assert.AreEqual(4, obj.ICUPatient.BedNo);
        }
    }
}