using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges
{
    public class BadgeContent
    {
        public int BadgeId { get; set; }
        public List<string> DoorName { get; set; }
        public BadgeContent(int badgeId, List<string> doorName)
        {
            BadgeId = badgeId;
            DoorName = doorName; 
        }
    }
}
