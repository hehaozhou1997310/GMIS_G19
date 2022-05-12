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
       

        private List<StudentGroup> student2;
        public List<Class> StudentGroup { get { return student; } set { } }
        

        public Enrollee()
        {
            student = Agency.LoadAll();
            student1 = Agency.LoadAllMeeting();
            student2 = Agency.LoadAllStudentGroup();
            VisibleMembers = new ObservableCollection<Class>(student);
        }

        public ObservableCollection<Class> GetViewableList()
        {
            return VisibleMembers;
        }

    }

}
