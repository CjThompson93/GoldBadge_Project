using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns
{

    public enum ClaimType { Car = 1, Home, Theft }
    public class ClaimsContent
    {
        public int ClaimId { get; set; }
        public ClaimType TypeOfClaim {get; set;}
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public string Valid()
        {
            TimeSpan differenceOfDates = DateOfClaim - DateOfIncident;
            double differenceOfDatesInDays = differenceOfDates.TotalDays;

            if(differenceOfDatesInDays <=30)
            {
                IsValid = true;
                return "This is a valid claim.";
            }
            else
            {
                IsValid = false;
                return "This is Not a valid claim.";
            }
        }
        public ClaimsContent(int claimId, ClaimType typeOfClaim, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            TypeOfClaim = typeOfClaim;
            Description = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
