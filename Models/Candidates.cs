using System;
using System.Collections.Generic;

namespace CandidateProcessingTest.Models
{
    class Candidates
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        public string Location {get; set;}
        public IEnumerable<WorkHistory> WorkHistory {get; set;}
    }
}


