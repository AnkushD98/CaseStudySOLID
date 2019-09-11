using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseStudyPart2.Models;
using NUnit.Framework;

namespace CaseStudyPart2.Tests
{
    [TestFixture]
    class NUnitTestTemperature
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(AlertGenerator.Temp.Fever, AlertGenerator.CheckTemperature(100));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(AlertGenerator.Temp.Normal, AlertGenerator.CheckTemperature(99));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(AlertGenerator.Temp.Normal, AlertGenerator.CheckTemperature(98.4));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(AlertGenerator.Temp.Cold, AlertGenerator.CheckTemperature(98));
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(AlertGenerator.Temp.Cold, AlertGenerator.CheckTemperature(97));
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(AlertGenerator.Temp.Hypothermia, AlertGenerator.CheckTemperature(96));
        }

        [Test]
        public void Test7()
        {
            Assert.AreEqual(AlertGenerator.Temp.Hypothermia, AlertGenerator.CheckTemperature(95.5));
        }

        [Test]
        public void Test8()
        {
            Assert.AreEqual(AlertGenerator.Temp.Loss, AlertGenerator.CheckTemperature(95));
        }

        [Test]
        public void Test9()
        {
            Assert.AreEqual(AlertGenerator.Temp.Loss, AlertGenerator.CheckTemperature(94));
        }

        [Test]
        public void Test10()
        {
            Assert.AreEqual(AlertGenerator.Temp.Sleepy, AlertGenerator.CheckTemperature(93));
        }

        [Test]
        public void Test11()
        {
            Assert.AreEqual(AlertGenerator.Temp.Sleepy, AlertGenerator.CheckTemperature(92));
        }

        [Test]
        public void Test12()
        {
            Assert.AreEqual(AlertGenerator.Temp.Emergency, AlertGenerator.CheckTemperature(91));
        }

        [Test]
        public void Test13()
        {
            Assert.AreEqual(AlertGenerator.Temp.Emergency, AlertGenerator.CheckTemperature(90));
        }

        [Test]
        public void Test14()
        {
            Assert.AreEqual(AlertGenerator.Temp.Emergency, AlertGenerator.CheckTemperature(89));
        }

        [Test]
        public void Test15()
        {
            Assert.AreEqual(AlertGenerator.Temp.InvalidInput, AlertGenerator.CheckTemperature(60));
        }

        [Test]
        public void Test16()
        {
            Assert.AreEqual(AlertGenerator.Temp.InvalidInput, AlertGenerator.CheckTemperature(-63));
        }
    }
}