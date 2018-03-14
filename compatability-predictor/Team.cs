using System;
using System.Collections.Generic;
namespace compatabilitypredictor
{
    public class Team
    {
        public List<Person> Members = new List<Person>();
        public int getIntelligenceAverage
        {
            get
            {
                int sum = 0;
                foreach (var member in Members)
                {
                    sum += member.Intelligence;
                }

                return sum / Members.Count;
            }
        }

        public int getIntelligenceMax
        {
            get
            {
                int max = 0;
                foreach(var member in Members)
                {
                    if(member.Intelligence > max)
                    {
                        max = member.Intelligence;
                    }
                }
                return max;
            }
        }


        public void addMember(Person p)
        {
            Members.Add(p);
        }
    }
}
