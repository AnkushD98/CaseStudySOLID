using System;
using System.Collections.Generic;
using System.Text;
using DataModelsLib;
using NUnit.Framework;
using TemperatureCheckerLib;

namespace PatientMonitoringWebService.Tests
{
    [TestFixture]
    class TemperatureCheckerTests
    {
        private readonly TempChecker obj = new TempChecker();
        [Test]
        public void Test1()
        {
            Assert.AreEqual(Vitals.Temp.Fever, obj.CheckTemp(100));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(Vitals.Temp.Normal, obj.CheckTemp(99));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(Vitals.Temp.Normal, obj.CheckTemp(98.4));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(Vitals.Temp.Cold, obj.CheckTemp(98));
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(Vitals.Temp.Cold, obj.CheckTemp(97));
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(Vitals.Temp.Hypothermia, obj.CheckTemp(96));
        }

        [Test]
        public void Test7()
        {
            Assert.AreEqual(Vitals.Temp.Hypothermia, obj.CheckTemp(95.5));
        }

        [Test]
        public void Test8()
        {
            Assert.AreEqual(Vitals.Temp.Loss, obj.CheckTemp(95));
        }

        [Test]
        public void Test9()
        {
            Assert.AreEqual(Vitals.Temp.Loss, obj.CheckTemp(94));
        }

        [Test]
        public void Test10()
        {
            Assert.AreEqual(Vitals.Temp.Sleepy, obj.CheckTemp(93));
        }

        [Test]
        public void Test11()
        {
            Assert.AreEqual(Vitals.Temp.Sleepy, obj.CheckTemp(92));
        }

        [Test]
        public void Test12()
        {
            Assert.AreEqual(Vitals.Temp.Emergency, obj.CheckTemp(91));
        }

        [Test]
        public void Test13()
        {
            Assert.AreEqual(Vitals.Temp.Emergency, obj.CheckTemp(90));
        }

        [Test]
        public void Test14()
        {
            Assert.AreEqual(Vitals.Temp.Emergency, obj.CheckTemp(89));
        }

        [Test]
        public void Test15()
        {
            Assert.AreEqual(Vitals.Temp.InvalidInput, obj.CheckTemp(60));
        }

        [Test]
        public void Test16()
        {
            Assert.AreEqual(Vitals.Temp.InvalidInput, obj.CheckTemp(-63));
        }

    }
}
