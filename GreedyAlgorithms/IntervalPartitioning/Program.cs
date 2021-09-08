using System;
using System.IO;
using System.Collections.Generic;
using IntervalProblems;

namespace IntervalScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            string classesPath = "jobs.txt";
            string[] rawClasses = File.ReadAllLines(classesPath);
            
            // Process all of the jobs
            List<Class> classes = new List<Class>();
            foreach (string line in rawClasses)
            {
                string[] classParams = line.Split(",");
                Class newClass = new Class(classParams[0], int.Parse(classParams[1]), int.Parse(classParams[2]));
                classes.Add(newClass);
            }

            // Add compatible jobs
            List<Classroom> classrooms = new List<Classroom>();
            classes.Sort(new ClassComparer());
            int nextNumber = 1;
            foreach (Class lecture in classes)
            {
                bool foundClassroom = false;
                foreach (Classroom classroom in classrooms)
                {
                    if (!foundClassroom && classroom.checkAvailability(lecture))
                    {
                        classroom.addClass(lecture);
                        foundClassroom = true;
                    }
                }
                if (!foundClassroom)
                {
                    Classroom newClassroom = new Classroom(nextNumber++);
                    newClassroom.addClass(lecture);
                    classrooms.Add(newClassroom);
                }
            }

            foreach (Classroom classroom in classrooms)
            {
                Console.WriteLine(classroom.printClasses());
            }
        }
    }
}
