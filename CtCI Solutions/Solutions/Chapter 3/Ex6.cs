using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions.Solutions
{
    public partial class Ch3 // Chapter Number
    {
        public static class Ex6 // Exercise number
        {
            /* Exercise 3.6
             * 
             * Animal Shelter: An animal shelter, which holds only dogs and cats,
             * operates on a strictly "first in, first out" basis.
             * People must adopt either the "oldest" (based on arrival time) of all animals at the shelter,
             * or they can select whether they would prefer a dog or a cat (and will receive the oldest animal
             * of that type).
             * They cannot select which specific animal they would like.
             * Create the data structures to maintain this system and implement operations such as 'enqueue',
             * 'dequeueAny', 'dequeueDog', and 'dequeueCat'.
             * You may use the built-in LinkedList data structure.
             */
            
            public class Animal
            {
                public readonly DateTime ArrivalTime = DateTime.Now;
            }

            public class Cat: Animal { }
            public class Dog: Animal { }

            public class AnimalShelter
            {
                private Queue<Dog> DogQueue = new Queue<Dog>();
                private Queue<Cat> CatQueue = new Queue<Cat>();
                public int AnimalCount
                {
                    get { return DogCount + CatCount; }
                }
                public int DogCount
                {
                    get { return DogQueue.Count; }
                }
                public int CatCount
                {
                    get { return CatQueue.Count; }
                }

                public void Enqueue(Animal animal)
                {
                    switch (animal)
                    {
                        case Cat cat:
                            CatQueue.Enqueue(cat);
                            break;
                        case Dog dog:
                            DogQueue.Enqueue(dog);
                            break;
                        default:
                            break;
                    }
                }

                public Animal DequeueAny()
                {
                    if (AnimalCount == 0) { throw new System.InvalidOperationException("Cannot dequeue from an empty shelter."); }
                    if (DogCount == 0) { return CatQueue.Dequeue(); }
                    if (CatCount == 0) { return DogQueue.Dequeue(); }
                    return (DogQueue.Peek().ArrivalTime < CatQueue.Peek().ArrivalTime) 
                        ? DogQueue.Dequeue() 
                        : (Animal)CatQueue.Dequeue();
                }

                public Dog DequeueDog()
                {
                    if (DogCount == 0) { throw new System.InvalidOperationException("Cannot dequeue Dog when there are no dogs."); }
                    return DogQueue.Dequeue();
                }

                public Cat DequeueCat()
                {
                    if (CatCount == 0) { throw new System.InvalidOperationException("Cannot dequeue Cat when there are no cats."); }
                    return CatQueue.Dequeue();
                }
            }
        }
    }
}
