using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns
{
    public class ClaimsRepo
    {
        private readonly Queue<ClaimsContent> _claimQueue = new Queue<ClaimsContent>();

        //Creating claims
        public bool AddClaimToDirectory(ClaimsContent newClaim)
        {
            int startingCount = _claimQueue.Count;
            _claimQueue.Enqueue(newClaim);
            bool wasAdded = _claimQueue.Count > startingCount;
            return wasAdded;
        }
        //Read (Get all claims)
        public Queue<ClaimsContent> GetAllClaimsFromQueue()
        {
            return _claimQueue;
        }

        public ClaimsContent PeekClaimFromQueue()
        {
            var claim = _claimQueue.Peek();
            return claim;
        }

        public ClaimsContent GetClaimsFromQueueById(int claimId)
        {
            foreach (var item in _claimQueue)
            {
                if(item.ClaimId == claimId)
                {
                    return item;
                }
            }
            return null;
        }
        //Updating Claims
        public bool UpdateExistingClaimById(int claimId, ClaimsContent updatedClaim)
        {
            ClaimsContent oldClaim = GetClaimsFromQueueById(claimId);
            if (oldClaim != null)
            {
                oldClaim.ClaimId = updatedClaim.ClaimId;
                oldClaim.Description = updatedClaim.Description;
                oldClaim.TypeOfClaim = updatedClaim.TypeOfClaim;
                oldClaim.ClaimAmount = updatedClaim.ClaimAmount;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;

                return true;
            }
            else
            {
                return false;
            }
        }
            //Dequeue Claims
             public bool DequeueFirstClaim(string response)
             {
                string userResponse = response.ToLower();
                int initialCount = _claimQueue.Count;
                if(userResponse == "y" || userResponse == "yes")
                {
                    _claimQueue.Dequeue();
                    if(initialCount > _claimQueue.Count)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
             }
    }
}
