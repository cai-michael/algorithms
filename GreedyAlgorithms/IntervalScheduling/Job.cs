using System.Collections.Generic;

namespace IntervalProblems
{
    public class Job
    {
        public string name;
        public int start;
        public int end;
        public Job(string name, int start, int end)
        {
            this.name = name;
            this.start = start;
            this.end = end;
        }
    }
    public class JobComparer : IComparer<Job>
    {
        public int Compare(Job a, Job b)
        {
            if (a.end == b.end)
            {
                return 0;
            }
            else if (a.end < b.end)
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
