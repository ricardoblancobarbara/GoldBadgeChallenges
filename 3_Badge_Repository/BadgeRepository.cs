using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge_Repository
{
    public class BadgeRepository
    {
        private Dictionary<int, Badge> _dictionaryOfBadge = new Dictionary<int, Badge>();

        // CRUD
        // Create
        public void CreateBadge(int entryId, Badge badge) // be careful the id is not the same as BadgeID
        {
            _dictionaryOfBadge.Add(entryId, badge);
        }

        // Read
        public Dictionary<int, Badge> ReadAllBadge()
        {
            return _dictionaryOfBadge;
        }

        // Update
        public bool UpdateBadge(int originalBadgeID, Badge newBadge)
        {
            // Find original badge
            Badge oldBadge = ReadBadgeByID(originalBadgeID);

            // Update the original badge
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Name = newBadge.Name;
                oldBadge.ListOfDoors = newBadge.ListOfDoors;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool DeleteBadge(int BadgeId )
        {
            Badge badge = ReadBadgeByID(BadgeId);
            if (badge == null)
            {
                return false;
            }

            int initialCount = _dictionaryOfBadge.Count;
            _dictionaryOfBadge.Remove(BadgeId);

            if (initialCount > _dictionaryOfBadge.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Helper
        public Badge ReadBadgeByID(int entryId) 
        {
            Dictionary<int, Badge> dictionaryOfBadge = _dictionaryOfBadge;

            foreach (var badge in dictionaryOfBadge)
            {
                if (dictionaryOfBadge.ContainsKey(entryId))
                {
                    return dictionaryOfBadge[entryId];
                }
            }
            return null;
        }
    }
}


