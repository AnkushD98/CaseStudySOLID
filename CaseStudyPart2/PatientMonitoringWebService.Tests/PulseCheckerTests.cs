using System;
using System.Collections.Generic;
using System.Text;
using DataModelsLib;
using NUnit.Framework;
using PulseCheckerLib;

namespace PatientMonitoringWebService.Tests
{
    [TestFixture]
    class PulseCheckerTests
    {
        private readonly PulseChecker obj = new PulseChecker();
        [Test]
        public void Test1()
        {
            Assert.AreEqual(Vitals.Pulse.VeryHigh, obj.CheckPulse(221));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(Vitals.Pulse.Excercise, obj.CheckPulse(220));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(Vitals.Pulse.Excercise, obj.CheckPulse(170));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(Vitals.Pulse.Excercise, obj.CheckPulse(100));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual(Vitals.Pulse.HealthyResting, obj.CheckPulse(80));
        }
        [Test]
        public void Test6()
        {
            Assert.AreEqual(Vitals.Pulse.HealthyResting, obj.CheckPulse(60));
        }
        [Test]
        public void Test7()
        {
            Assert.AreEqual(Vitals.Pulse.Sleeping, obj.CheckPulse(50));
        }
        [Test]
        public void Test8()
        {
            Assert.AreEqual(Vitals.Pulse.Sleeping, obj.CheckPulse(40));
        }
        [Test]
        public void Test9()
        {
            Assert.AreEqual(Vitals.Pulse.BelowHealthy, obj.CheckPulse(30));
        }
        [Test]
        public void Test10()
        {
            Assert.AreEqual(Vitals.Pulse.BelowHealthy, obj.CheckPulse(0));
        }
        [Test]
        public void Test11()
        {
            Assert.AreEqual(Vitals.Pulse.InvalidInput, obj.CheckPulse(-45));
        }

    }
}
