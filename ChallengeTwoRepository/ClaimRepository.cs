using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim_Repository
{
    public class ClaimRepository
    {
        private Queue<Claim> _queueOfClaim = new Queue<Claim>();

        // CRUD
        // Create a claim in a Queue
        public void CreateClaimQ(Claim claim)
        {   
            _queueOfClaim.Enqueue(claim);
        }

        // Read Queue of claim
        public Queue<Claim> ReadClaimQueue()
        {
            return _queueOfClaim;
        }

        // See next claim in a Queue
        public Claim NextClaimQ()
        {
            return _queueOfClaim.Peek();
        }

        // Remove next claim in a Queue
        public void RemoveNextClaimQ()
        {
            _queueOfClaim.Dequeue();
        }

    }
}
