using PracticeProblems.CtCi.Moderate;
using Xunit;

namespace TestProject.CtCi.Moderate
{
    public class Calculator1626Tests
    {
        [Theory]
        [InlineData("2-6-7*8/2+5", -27)]
        [InlineData("", double.MinValue)]
       public void ComputeTests(string equation, double expected)
        {
            // Act
            var result = Calculator1626.Compute(equation);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
