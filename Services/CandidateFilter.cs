using System;
using System.Collections.Generic;
using CandidateProcessingTest.Models;

namespace CandidateProcessingTest.Services
{   
    class CandidateFilter{
        public IEnumerable<Candidates> arrCandidates;        
        public CandidateFilter (IEnumerable<Candidates> candidates)
        {
            /**
                Takes in the deserialized json object from candidates.json and stores it in the class variable.
            **/
            this.arrCandidates = candidates;
        }
        
        public List<ContactDetails> GetCandidatesByJobTitle(string jobTitle, int yearsExperience)
        {                        
            /**
                This method takes in the dynamic filter parameters, loops through the candidates and checks the duration of each
                job history entry and returns the candidates contact details based on the filter criteria.
            **/
            List<ContactDetails> filteredContactDetails = new List<ContactDetails>();
            foreach (Candidates candidate in arrCandidates)
            {                
                IEnumerable<WorkHistory> history = candidate.WorkHistory;
                foreach (WorkHistory item in history)
                {
                    string title = item.JobTitle;                    
                    if (jobTitle == title)
                    {
                        DateTime startDate = Convert.ToDateTime(item.StartDate);
                        DateTime endDate;
                        if (item.EndDate is null)
                        {
                            endDate = DateTime.Now;
                        } 
                        else 
                        {
                            endDate = Convert.ToDateTime(item.EndDate);
                        }
                        
                        int years = endDate.Year - startDate.Year;
                        if (startDate.Month > endDate.Month || (startDate.Month == endDate.Month && startDate.Day > endDate.Day))
                        {
                            years--;
                        }                        
                        if (years >= yearsExperience)
                        {
                            ContactDetails details = new ContactDetails(candidate.Name, candidate.Email, candidate.Phone, candidate.Location);                            
                            filteredContactDetails.Add(details);
                        }
                    }
                }
            }

            return filteredContactDetails;
        }
    }
}