using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19
{
    public class Enrollee
    {

        private List<Class> student;
        public List<Class> Class { get { return student; } set { } }
        private ObservableCollection<Class> viewableStudent;
        public ObservableCollection<Class> VisibleMembers;

        private List<Meeting> student1;
        public List<Class> Meeting { get { return student; } set { } }
        private ObservableCollection<Meeting> viewableMembers;
     

        public Enrollee()
        {
            student = Agency.LoadAll();
            VisibleMembers = new ObservableCollection<Class>(student);
            student1 = Agency.LoadAllMeeting1();
            VisibleMembers = new ObservableCollection<Class>(student);
        }

        public ObservableCollection<Class> GetViewableList()
        {
            return VisibleMembers;
        }

    }

}
