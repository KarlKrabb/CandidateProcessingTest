using System;

namespace CandidateProcessingTest.Models
{
    class ContactDetails
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        public string Location {get; set;}

        public ContactDetails(string name, string email, string phone, string location)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Location = location;
        }
    }
}