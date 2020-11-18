using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FunctionalityForSquadFinder;
using SquadFinder3Tier;
using System.Linq;

namespace SquadFinder3TierFrontEnd
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public CRUDoperationsForMembers _crudOps = new CRUDoperationsForMembers();


        public Window1()
        {
            InitializeComponent();
            SquadListBox_ContainsList();
        }

        private void SquadListBox_ContainsList()
        {
            SquadListBox.ItemsSource = _crudOps.GetAllSquads();
            
        }

       

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow homePage = new MainWindow();
            this.Visibility = Visibility.Hidden;
            homePage.Show();
        }



        private void SquadMemberListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SquadListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _crudOps.SetSelectedSquad(SquadListBox.SelectedItem);          
            if (_crudOps.SelectedSquad != null)
            {
                SquadMemberListBox.ItemsSource = _crudOps.GetAllSquadMembers(_crudOps.SelectedSquad.SquadId);
            }
        }
    }
}
