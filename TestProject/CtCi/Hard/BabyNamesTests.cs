using PracticeProblems.CtCi.Hard;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject.CtCi.Hard
{
    public class BabyNamesTests
    {
        [Fact]
        public void TrueFreequenciesTests()
        {
            var freeq = new Dictionary<string, int>()
           {
               {"John", 15 },
                {"Jon", 12 },
               {"Chris", 13 },
               {"Kris", 4 },
               {"Christopher", 19 }
           };

            var synonyms = new string[,]
            {
                { "Jon", "John" },
                { "John", "Johnny" },
                { "Chris", "Kris" },
                { "Chris", "Christopher" },
            };


            var result = new BabyNames().TrueFreequency(freeq, synonyms);

            Assert.Equal(2, result.Count());
            Assert.Equal(27, result.Single(x => x.Key == "Jon").Value);
            Assert.Equal(36, result.Single(x => x.Key == "Chris").Value);
        }
    }
}
