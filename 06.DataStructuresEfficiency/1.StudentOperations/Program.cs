using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentOperations
{
    public class Program
    {
        public static void Main()
        {
            var courses = new SortedDictionary<string, List<Student>>();

            foreach (string line in File.ReadLines("../.../students.txt"))
            {
                // Each line represents one student
                var fields = line.Split('|').Select(s => s.Trim()).ToArray();
                var fname = fields[0];
                var lname = fields[1];
                var course = fields[2];

                // Find the list of students for this course
                List<Student> students;
                if (!courses.TryGetValue(course, out students))
                {
                    // New course -> create a list of students for it
                    students = new List<Student>();
                    courses.Add(course, students);
                }

                var student = new Student() { FirstName = fname, LastName = lname };
                students.Add(student);
            }

            foreach (var course in courses)
            {
                Console.WriteLine(
                    "{0}: {1}",
                    course.Key,
                    string.Join(", ", course.Value.OrderBy(s => s.LastName).ThenBy(s => s.FirstName)));
            }
        }

        private struct Student
        {
            public string FirstName, LastName;

            public override string ToString()
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
