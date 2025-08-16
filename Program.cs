using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activitys_37
{
    internal class Program
    {
        class Applicant
        {
            public string Name { get; }
            public double GPA { get; }
            public double Income { get; }
            public List<string> Extracurriculars { get; }
            public List<string> Awards { get; }

            public Applicant(string name, double gpa, double income, List<string> extra, List<string> awards)
            {
                Name = name;
                GPA = gpa;
                Income = income;
                Extracurriculars = extra.Select(e => e.ToLower()).ToList();
                Awards = awards.Select(a => a.ToLower()).ToList();
            }

            public List<string> Evaluate()
            {
                var result = new List<string>();

                if (GPA >= 3.5 && Income < 50000)
                    result.Add("Merit-Need Scholarship (high GPA + low income)");

                if (GPA >= 3.8 && Awards.Contains("science fair"))
                    result.Add("STEM Excellence Scholarship (science fair award)");

                if (Extracurriculars.Contains("sports") && GPA >= 2.5)
                    result.Add("Athletic Scholarship (sports involvement)");

                if (Income < 30000 || Extracurriculars.Contains("volunteer"))
                    result.Add("Community Service Scholarship (low income or volunteering)");

                return result;
            }
        }

        static void Main()
        {
            var applicants = new List<Applicant>
        {
            new Applicant("Aly", 3.9, 20000, new List<string>{"Volunteer","Debate"}, new List<string>{"Science Fair"}),
            new Applicant("Bea", 3.2, 60000, new List<string>{"Sports"}, new List<string>{"Math Contest"}),
            new Applicant("Carms", 3.6, 40000, new List<string>{"Music"}, new List<string>())
        };

            foreach (var a in applicants)
            {
                Console.WriteLine($"\nApplicant: {a.Name}");
                var eligible = a.Evaluate();
                if (eligible.Count == 0)
                    Console.WriteLine("  Not eligible for any scholarships.");
                else
                    foreach (var s in eligible)
                        Console.WriteLine($"  Eligible: {s}");
            }
        }
    }
}
        
