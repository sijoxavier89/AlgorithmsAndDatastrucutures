using PracticeProblems.BFS;
using System.Linq;
using Xunit;

namespace TestProject.BFS
{
    public class KevinBaconGraphTests
    {
        [Fact]
        public void Test()
        {
            KevinBaconGraph kbg = new KevinBaconGraph("Actors.txt", "Movies.txt", "ActorsAndMovies.txt");
            var result = kbg.GetActors("Kevin Bacon", 1);
            Assert.Equal(6, result.Count());
        }
    }
}
