using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private string sex;

        public Animal(int age, string name, string sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Sex
        {
            get { return this.sex; }
            private set { this.sex = value; }
        }

        public abstract void ProduceSound();

        public static double CalculateAverage(Animal[] animals)
        {
            double sum = 0d;
            foreach (Animal animal in animals)
            {
                sum += animal.age;
            }
            return sum / (double)animals.Length;
        }
    }
}
