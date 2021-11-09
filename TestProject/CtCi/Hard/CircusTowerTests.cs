using PracticeProblems.CtCi.Hard;
using Xunit;

namespace TestProject.CtCi.Hard
{
    public class CircusTowerTests
    {

        [Fact]
        public void MaxSeequence()
        {
            var persons = new Person[]
            {
                new Person(65, 100),
                new Person(70, 150),
                new Person(56, 90),
                new Person(75, 190),
                new Person(60, 95),
                new Person(68, 110)
            };

            var result = new CircusTower().MaxHeightSeequence(persons);

           
        }
    }
}
