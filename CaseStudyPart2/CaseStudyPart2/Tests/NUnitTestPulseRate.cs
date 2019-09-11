using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NUnit.Framework;

namespace CaseStudyPart2.Tests
{
    [TestFixture]
    class NUnitTestPulseRate
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(AlertGenerator.Pulse.VeryHigh, AlertGenerator.CheckPulseRate(221));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(AlertGenerator.Pulse.Excercise, AlertGenerator.CheckPulseRate(220));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(AlertGenerator.Pulse.Excercise, AlertGenerator.CheckPulseRate(170));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(AlertGenerator.Pulse.Excercise, AlertGenerator.CheckPulseRate(100));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual(AlertGenerator.Pulse.HealthyResting, AlertGenerator.CheckPulseRate(80));
        }
        [Test]
        public void Test6()
        {
            Assert.AreEqual(AlertGenerator.Pulse.HealthyResting, AlertGenerator.CheckPulseRate(60));
        }
        [Test]
        public void Test7()
        {
            Assert.AreEqual(AlertGenerator.Pulse.Sleeping, AlertGenerator.CheckPulseRate(50));
        }
        [Test]
        public void Test8()
        {
            Assert.AreEqual(AlertGenerator.Pulse.Sleeping, AlertGenerator.CheckPulseRate(40));
        }
        [Test]
        public void Test9()
        {
            Assert.AreEqual(AlertGenerator.Pulse.BelowHealthy, AlertGenerator.CheckPulseRate(30));
        }
        [Test]
        public void Test10()
        {
            Assert.AreEqual(AlertGenerator.Pulse.BelowHealthy, AlertGenerator.CheckPulseRate(0));
        }
        [Test]
        public void Test11()
        {
            Assert.AreEqual(AlertGenerator.Pulse.InvalidInput, AlertGenerator.CheckPulseRate(-45));
        }
    }
}