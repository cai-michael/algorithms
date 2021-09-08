using System.Collections.Generic;

namespace IntervalProblems
{
    public class Class
    {
        public string name;
        public int start;
        public int end;
        public Class(string name, int start, int end)
        {
            this.name = name;
            this.start = start;
            this.end = end;
        }
    }

    // Compare the start of classes for interval partitioning. 
    public class ClassComparer : IComparer<Class>
    {
        public int Compare(Class a, Class b)
        {
            if (a.start == b.start)
            {
                return 0;
            }
            else if (a.start < b.start)
            {
                return -1;
            }     
            else
            {
                return 1;
            }
            
        }
    }
}
