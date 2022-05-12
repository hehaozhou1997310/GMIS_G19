using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GMIS_G19
{
    /// <summary>
    /// Interaction logic for SubMasterView.xaml
    /// StudentL=====
    /// </summary>
    
    public partial class SubMasterView : Window
    {
        private const string STUDENT_LIST_KEY = "studentList";
        Enrollee enrollee;
        public SubMasterView()
        {
            InitializeComponent();
            enrollee = (Enrollee)(Application.Current.FindResource(STUDENT_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Class c in enrollee.GetViewableList())
            {
                gmisListBox.Items.Add(c.ToString());
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
