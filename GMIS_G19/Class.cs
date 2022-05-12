using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19
{
       public enum Day { Monday, Tusesday, Wednesday, Thursday, Friday, Saturday, Sunday };
       public class Class
    {  
            public int Class_id { get; set; }
            public int Group_id { get; set; }
            public Day Day { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public string Room { get; set; }
       
        public override string ToString()
        {
            return Class_id + "completed by" + Group_id + " in " + Room + " From " + Day + Start+"-"+ End; 
        }


    }
}



