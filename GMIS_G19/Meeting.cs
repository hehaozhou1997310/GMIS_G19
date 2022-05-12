using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19
{
    
    class Meeting
    {
        public int Meeting_id { get; set; }
        public int Group_id { get; set; }
        public Day Day { get; set; }
        public String Start { get; set; }
        public String End { get; set; }
        public string Room { get; set; }

    public override string ToString()
       {
            return Meeting_id + "completed by" + Group_id + " in " + Room + " From " + Day + Start + "-" + End;
        }
    
    }

   
}
