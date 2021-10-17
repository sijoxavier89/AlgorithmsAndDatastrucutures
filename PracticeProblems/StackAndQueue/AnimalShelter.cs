using System.Collections.Generic;

namespace PracticeProblems.StackAndQueue
{
    public class AnimalShelter
    {
        public LinkedList<Animal> animals;
        private LinkedListNode<Animal> prev;
        public AnimalShelter()
        {
      
        }

        public void Enqueue(Animal animal)
        {
            var current = new LinkedListNode<Animal>(animal);
            if (animals == null)
            {
               
                animals = new LinkedList<Animal>();
                animals.AddFirst(current);
               
            }
            else
            {
                animals.AddBefore(prev,current);
            }
            prev = current;
        }

        public Animal DequeueAny()
        {
            var oldest = animals.First;
            animals.RemoveFirst();

            return oldest.Value;
        }

        public Animal DequeueDog()
        {
            var animal = animals.First;

            while(!animal.Value.Type.Equals("Dog"))
            {
                animal = animal.Next;
            }

            var result = animal.Value;
            animals.Remove(animal);
            return result;
        }
    }


    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Animal(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
