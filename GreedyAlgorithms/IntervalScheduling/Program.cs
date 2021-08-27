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
            string jobsPath = "jobs.txt";
            string[] rawJobs = File.ReadAllLines(jobsPath);
            
            // Process all of the jobs
            List<Job> jobs = new List<Job>();
            foreach (string line in rawJobs)
            {
                string[] jobParams = line.Split(",");
                Job newJob = new Job(jobParams[0], int.Parse(jobParams[1]), int.Parse(jobParams[2]));
                jobs.Add(newJob);
            }
            jobs.Sort(new JobComparer());
            foreach (Job job in jobs)
            {
                Console.WriteLine(job.end);
            }
            
        }
    }

}
