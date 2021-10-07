using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        //Creating Badges 
        public bool AddBadgeToDictionary(BadgeContent badge)
        {
            int initialCount = _dictionary.Count;
            _dictionary.Add(badge.BadgeId, badge.DoorName);

            bool wasAdded = _dictionary.Count > initialCount;
            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _dictionary;
        }
        //Update (Add Content)
        public bool EditDoorById(int badgeId, string doorName)
        {
            int firstCount = _dictionary[badgeId].Count;
            _dictionary[badgeId].Add(doorName);
            int secondCount = _dictionary[badgeId].Count;
            return secondCount > firstCount;
        }
        //Update (Remove Content)
        public bool EditDoorRemoveById(int badgeId, string doorName)
        {
            int firstCount = _dictionary[badgeId].Count;
            _dictionary[badgeId].Remove(doorName);
            int secondCount = _dictionary[badgeId].Count;
            return firstCount < secondCount;
        }
        //Helper Methods 
        public List<string> GetBadgeInfoById(int badgeId)
        {
            return _dictionary[badgeId];
        }
    }
}
