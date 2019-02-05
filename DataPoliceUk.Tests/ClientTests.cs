using System;
using NUnit.Framework;

namespace DataPoliceUk.Tests
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void SampleTest()
        {
            // Arrange/Act
            var actual = "Unit Testing";

            // Assert
            Assert.That(actual, Is.EqualTo("Unit Testing"));
        }
    }
}
