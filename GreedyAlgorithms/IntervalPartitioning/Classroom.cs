using System.Collections.Generic;
using IntervalProblems;

namespace IntervalProblems
{
    public class Classroom
    {
        public int number;
        public List<Class> classes;
        private int mostRecentClassEnd;

        public Classroom(int number)
        {
            this.number = number;
            this.classes = new List<Class>();
            this.mostRecentClassEnd = -1;
        }
        public bool checkAvailability(Class classToCheck)
        {
            bool available = false;
            if (classToCheck.start >= this.mostRecentClassEnd)
            {
                available = true;
            }

            return available;
        }

        public void addClass(Class classToAdd)
        {
            classes.Add(classToAdd);
            mostRecentClassEnd = classToAdd.end;
        }

        public string printClasses()
        {
            string toPrint = "Classroom " + number + ": ";
            foreach (Class lecture in classes)
            {
                toPrint += lecture.name + ", ";
            }
            toPrint = toPrint.Substring(0, toPrint.Length - 2);
            return toPrint;
        }
    }
}

