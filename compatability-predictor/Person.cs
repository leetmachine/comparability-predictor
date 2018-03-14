using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace compatabilitypredictor
{
    public class Person
    {
        const int weight = 50;

        public string Name { get; set;  }
        public int Intelligence { get; set; }
        public int[] Scores = new int[1];
        public double ApplicantScore = 0;


        public Person(dynamic person)
        {
            Name = person.name;
            Intelligence = person.intelligence;

        }

        public Person(dynamic person, Team team)
        {
            Name = person.name;
            Intelligence = person.intelligence;
            SetIntelligenceScore(team);
            SetApplicantScore();

        }

        public void SetIntelligenceScore(Team team)
        {
            int average = team.getIntelligenceAverage;
            int max = team.getIntelligenceMax;

            if(Intelligence <= average)
            {
                Scores[0] = Intelligence / average;
            }
            else if(Intelligence <= max)
            {
                Scores[0] = (Intelligence / max) + 1;
                    
            }
            else
            {
                Scores[0] = (Intelligence / max) - 1;
            }

        }

        public double GetApplicantScore()
        {
            return ApplicantScore;
        }

        public void SetApplicantScore()
        {
           double sum = 0.0;

           foreach(int score in Scores)
            {
                sum += score * weight;
            }

            ApplicantScore = sum / 100;

        }
    }
}
