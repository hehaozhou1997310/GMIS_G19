﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GMIS_G19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewForSearch myViewForSearch = new ViewForSearch();
            myViewForSearch.Show();
            this.Hide();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MasterView myMasterView = new MasterView();
            myMasterView.Show();
            this.Hide();

        }

        
    }
}
