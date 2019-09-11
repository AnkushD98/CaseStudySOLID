using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudyPart2.Models;
using NUnit.Framework;

namespace CaseStudyPart2.Tests
{
    class NUnitTestFileFormat
    {
        [Test]
        public void Test40()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            dir += @"BadPatientData.json";
            Assert.Throws(typeof(FileNotFoundException), delegate
            {
                Deserializer.DeserializeObjects<Patient>(
                    dir, "JSON");
            });
        }

        [Test]
        public void Test43()
        {
            string dir = @"PatientData.json";
            var persons = Deserializer.DeserializeObjects<Patient>(dir, "JSON");
            var person = persons[0];
            //Console.WriteLine(person.PulseRate);
            Patient p = new Patient();
            p.PatientId = "TRJIW431";
            p.PulseRate = 75;
            p.Spo2 = 96;
            p.Temperature = 98.6;
            Assert.AreEqual(person.Temperature, p.Temperature);
            Assert.AreEqual(person.Spo2, p.Spo2);
            Assert.AreEqual(person.PulseRate, p.PulseRate);
            Assert.AreEqual(person.PatientId, p.PatientId);
        }
    }
}