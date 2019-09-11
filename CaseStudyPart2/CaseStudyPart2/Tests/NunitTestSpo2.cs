using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NUnit.Framework;

namespace CaseStudyPart2.Tests
{
    [TestFixture]
    class NunitTestSpo2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.InvalidInput, AlertGenerator.CheckSpo2(101));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.NormalHealthy, AlertGenerator.CheckSpo2(100));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.NormalHealthy, AlertGenerator.CheckSpo2(97));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.NormalHealthy, AlertGenerator.CheckSpo2(95));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.ClinicallyAcceptable, AlertGenerator.CheckSpo2(93));
        }
        [Test]
        public void Test6()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.ClinicallyAcceptable, AlertGenerator.CheckSpo2(91));
        }
        [Test]
        public void Test7()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.Hypoxemia, AlertGenerator.CheckSpo2(90));
        }
        [Test]
        public void Test8()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.Hypoxemia, AlertGenerator.CheckSpo2(80));
        }
        [Test]
        public void Test9()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.Hypoxemia, AlertGenerator.CheckSpo2(77));
        }
        [Test]
        public void Test10()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.LackOfO2, AlertGenerator.CheckSpo2(60));
        }
        [Test]
        public void Test11()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.LackOfO2, AlertGenerator.CheckSpo2(0));
        }
        [Test]
        public void Test12()
        {
            Assert.AreEqual(AlertGenerator.Spo2Level.InvalidInput, AlertGenerator.CheckSpo2(-90));
        }
    }
}