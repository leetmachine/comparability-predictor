using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace compatabilitypredictor
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string text = File.ReadAllText("input.txt");
            var js = JsonConvert.DeserializeObject<dynamic>(text);
            var teamInputArray = js.team;
            var applicantsInputArray = js.applicants;

            Team team = new Team();

            List<Person> scoredApplicants = new List<Person>();

            foreach (var person in teamInputArray)
            {
                Person p = new Person(person);
                team.addMember(p);

            }

            foreach (var applicant in applicantsInputArray)
            {
                Person p = new Person(applicant, team);
                scoredApplicants.Add(p);

            }

            var jso = JsonConvert.SerializeObject(scoredApplicants);
            File.WriteAllText("output.txt", jso);

        }
    }
}
