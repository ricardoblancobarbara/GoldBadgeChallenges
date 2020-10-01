using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim_Repository
{
    // Kinds of Type
    public enum KindOfType
    {
        Car = 1,
        Home = 2,
        Theft = 3,
    }

    // Plain Old C# Object (POCO)
    public class Claim
    {
        // Properties
        public int ID { get; set; }
        public KindOfType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        // Empty Constructor
        public Claim() { }

        // Overload Constructor
        public Claim(int id, KindOfType type, string description, double amount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ID = id;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
