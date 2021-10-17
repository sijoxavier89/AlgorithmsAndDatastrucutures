using PracticeProblems.StackAndQueue;
using Xunit;

namespace TestProject.StackandQueue
{
    public class AnimalShelterTests
    {
        AnimalShelter shelter;
        public AnimalShelterTests()
        {
            shelter = new AnimalShelter();
        }
        
        [Fact]
        public void Getdog_Test()
        {
            var animal1 = new Animal("Tommy", "Dog");
            var animal2 = new Animal("Mia", "Cat");
            var animal3 = new Animal("Ruby", "Dog");
            var animal4 = new Animal("Salsa", "Dog");

            shelter.Enqueue(animal1);
            shelter.Enqueue(animal2);
            shelter.Enqueue(animal3);
            shelter.Enqueue(animal4);

            Assert.Equal<Animal>(animal4, shelter.DequeueAny());
            Assert.Equal<Animal>(animal3, shelter.DequeueDog());

        }
    }
}
