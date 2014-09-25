using BiDIctionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    class Program
    {
        public static void Main()
        {
            var bdict = new BiDictionary<string, int, Person>();

            var people = new[]
        {
            new Person() { Name = "Peter", Age = 20, Town = "Sofia" },
            new Person() { Name = "Peter", Age = 20, Town = "Varna" },
            new Person() { Name = "Peter", Age = 25, Town = "Varna" },
            new Person() { Name = "Billy", Age = 20, Town = "Sofia" },
        };

            // Add people to dictionary
            foreach (var person in people)
            {
                bdict.Add(person.Name, person.Age, person);
            }

            Console.WriteLine("All people in the BiDictionary:");
            foreach (var triple in bdict)
            {
                Console.WriteLine(string.Join(Environment.NewLine, triple.Item3));
            }

            Console.WriteLine("All people named Peter: {0}", string.Join(", ", bdict.GetByK1("Peter")));
            Console.WriteLine("All people at age 20: {0}", string.Join(", ", bdict.GetByK2(20)));
            Console.WriteLine("All people at age 20, named Peter: {0}", string.Join(", ", bdict.GetByBoth("Peter", 20)));
        }

        private struct Person
        {
            public string Name;
            public int Age;
            public string Town;

            public override string ToString()
            {
                return string.Format("{{{0,-5}, {1}, {2}}}", this.Name, this.Age, this.Town);
            }
        }
    }
}
