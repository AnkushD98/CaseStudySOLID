using System;
using System.Collections.Generic;
using System.Text;
using DataModelsLib;
using NUnit.Framework;
using Spo2CheckerLib;
namespace CaseStudyPart2.Tests
{
    [TestFixture]
    public class Spo2CheckerTests
    {
        private Spo2Checker obj = new Spo2Checker();
        [Test]
        public void Test1()
        {
            Assert.AreEqual(Vitals.Spo2Level.InvalidInput, obj.CheckSpo2(101));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(Vitals.Spo2Level.NormalHealthy, obj.CheckSpo2(100));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(Vitals.Spo2Level.NormalHealthy, obj.CheckSpo2(97));
        }
        [Test]
        public void Test4()
        {
            Assert.AreEqual(Vitals.Spo2Level.NormalHealthy, obj.CheckSpo2(95));
        }
        [Test]
        public void Test5()
        {
            Assert.AreEqual(Vitals.Spo2Level.ClinicallyAcceptable, obj.CheckSpo2(93));
        }
        [Test]
        public void Test6()
        {
            Assert.AreEqual(Vitals.Spo2Level.ClinicallyAcceptable, obj.CheckSpo2(91));
        }
        [Test]
        public void Test7()
        {
            Assert.AreEqual(Vitals.Spo2Level.Hypoxemia, obj.CheckSpo2(90));
        }
        [Test]
        public void Test8()
        {
            Assert.AreEqual(Vitals.Spo2Level.Hypoxemia, obj.CheckSpo2(80));
        }
        [Test]
        public void Test9()
        {
            Assert.AreEqual(Vitals.Spo2Level.Hypoxemia, obj.CheckSpo2(77));
        }
        [Test]
        public void Test10()
        {
            Assert.AreEqual(Vitals.Spo2Level.LackOfO2, obj.CheckSpo2(60));
        }
        [Test]
        public void Test11()
        {
            Assert.AreEqual(Vitals.Spo2Level.LackOfO2, obj.CheckSpo2(0));
        }
        [Test]
        public void Test12()
        {
            Assert.AreEqual(Vitals.Spo2Level.InvalidInput, obj.CheckSpo2(-90));
        }

    }
}
