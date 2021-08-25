using System;
using System.Collections.Generic;
using System.IO;

namespace GaleShapley
{
    // Propose and Reject Algorithm
    class Program
    {
        static void Main(string[] args)
        {
            string malePath = "preferences_male.txt";
            string femalePath = "preferences_female.txt";
            string[] male_lines = File.ReadAllLines(malePath);
            string[] female_lines = File.ReadAllLines(femalePath);
            
            // Process the male preferences
            Queue<string> bachelors = new Queue<string>();
            Dictionary<string, string[]> malePreferences = new Dictionary<string, string[]>();
            Dictionary<string, int> maleProposals = new Dictionary<string, int>();
            foreach (string line in male_lines)
            {
                string maleName = line.Split("-")[0];
                string[] malePreferenceList = line.Split("-")[1].Split(",");
                bachelors.Enqueue(maleName);
                malePreferences[maleName] = malePreferenceList;
                maleProposals[maleName] = 0;
            }

            // Process the female preferences
            Dictionary<string, Dictionary<string, int>> femalePreferences = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> engagements = new Dictionary<string, string>();
            foreach (string line in female_lines)
            {
                string femaleName = line.Split("-")[0];
                string[] femalePreferenceList = line.Split("-")[1].Split(",");
                // Reverse the female preference list so lookup takes O(n) instead of O(n^2)
                Dictionary<string, int> invertedPreferenceList = new Dictionary<string, int>();
                for (int i = 0; i < femalePreferenceList.Length; i++)
                {
                    invertedPreferenceList[femalePreferenceList[i]] = i;
                }

                // Initialize each person to be not engaged
                engagements[femaleName] = null;
                femalePreferences[femaleName] = invertedPreferenceList;
            }

            // While there is still a man without a partner who has not proposed to every woman
            while (bachelors.Count != 0)
            {
                string elligibleBachelor = bachelors.Dequeue();

                // Find the next women he has not proposed to on his preference list
                int numProposals = maleProposals[elligibleBachelor];
                string potentialFiance = malePreferences[elligibleBachelor][numProposals];
                string currentPartner = engagements[potentialFiance];

                // If they are not engaged then the proposal succeeds
                if (currentPartner == null)
                {
                    engagements[potentialFiance] = elligibleBachelor;
                }
                else
                {
                    int bachelorsRank = femalePreferences[potentialFiance][elligibleBachelor];
                    int currentPartnerRank = femalePreferences[potentialFiance][currentPartner];
                    // Otherwise if the woman prefers the proposer to her current partner, the proposal succeeds
                    if (bachelorsRank < currentPartnerRank)
                    {
                        bachelors.Enqueue(currentPartner);
                        engagements[potentialFiance] = elligibleBachelor;
                    }
                    // Otherwise she rejects him.
                    else
                    {
                        bachelors.Enqueue(elligibleBachelor);
                    }
                }
                maleProposals[elligibleBachelor] += 1; 
            }

            foreach ((string female, string male) in engagements)
            {
                Console.WriteLine($"{male} ended up marrying {female}");
            }
        }
    }
}
