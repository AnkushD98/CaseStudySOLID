using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using ICUDBMySQLRepoInterfaceLib;
using ICUDBMySQLRepository;

namespace CaseStudyPart2.Tests
{
    [TestFixture]
    public class ICUDBMySQLRepoTests
    {
        [Test]
        public void TestRead()
        {
            Mock<IICUDBRepo> mockWrapper=new Mock<IICUDBRepo>();

            IICUDBRepo obj = mockWrapper.Object;
            ICUDBMySQLRepo obj1=new ICUDBMySQLRepo();
            string id="TRJIW432";
            int spo2=0, pulse=0;  double temp=0.0;
            obj1.ReadRecord(ref id,ref spo2,ref pulse,ref temp);
            Assert.AreEqual(spo2,97);
            Assert.AreEqual(temp,105);
            Assert.AreEqual(pulse,99);
        }
    }
}
