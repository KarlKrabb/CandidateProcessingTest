using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CandidateProcessingTest.Models;
using CandidateProcessingTest.Services;

namespace CandidateProcessingTest
{
    class Program
    {        
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("candidates.json"))
            {
                /**
                    I just imported the json from the file directly but i imagine this would generally come from an API or from a database query of sorts.
                **/
                string json = reader.ReadToEnd();
                IEnumerable<Candidates> items = JsonConvert.DeserializeObject<IEnumerable<Candidates>>(json);

                /**
                    - Below is the filter class, it takes in the candidate.json and stores the values to use in the filter method later on.
                    - if this program was an API that returned a list of candidates i would have created an interface that returns the filtered object instead of a class with a filter method.
                **/
                CandidateFilter CFilter = new CandidateFilter(items);

                Console.WriteLine("Please Sepcify Job Title"); // Software Engineer for the current example
                string title = Console.ReadLine();
                Console.WriteLine("Please Sepcify Years Of Experience Required In A Single Role"); // 5 for the current example
                int yearsRequired = Convert.ToInt32(Console.ReadLine()); //I would usually do validation for int inputs but for the sake of this example im assuming the input is correct.

                /**
                    The below is a list of filtered candidates that can be used in many different program use cases.
                **/
                List<ContactDetails> filteredCandidates = CFilter.GetCandidatesByJobTitle(title, yearsRequired);
                
                /**
                    I have just printed the filtered list out for the sake of the console app
                **/
                foreach (ContactDetails person in filteredCandidates)
                {
                    Console.WriteLine(person.Name);
                    Console.WriteLine(person.Email);
                    Console.WriteLine(person.Phone);
                    Console.WriteLine(person.Location);
                }
            }
            
        }
    }
}
