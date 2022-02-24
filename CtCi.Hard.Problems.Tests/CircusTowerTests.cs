using System.Collections.Generic;
using Xunit;

namespace CtCi.Hard.Problems.Tests
{

    public class CircusTowerTests
    {
        [Fact]
        public void TestMaxTower()
        {
            // Arrange
            List<Hwt> items = new List<Hwt>()
            {
                new Hwt(65, 100),
                new Hwt(70, 150),
                new Hwt(56, 90),
                new Hwt(75, 190),
                new Hwt(60, 95),
                new Hwt(68, 110)
            };

            // Act 
            var result = CircusTower.MaximumPeople(items);

            // Assert
            Assert.Equal(6, result.Count);
        }
    }
}
