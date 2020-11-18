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
using SquadFinder3Tier.Services;

namespace SquadFinder3TierFrontEnd
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public CRUDoperationsForMembers _crudOpsForMembers = new CRUDoperationsForMembers();
        public CRUDoperationsForSquadMembers _crudOpsForSquadMembers = new CRUDoperationsForSquadMembers();
        public CRUDoperationsForSquad _crudOpsForSquad = new CRUDoperationsForSquad();

        public Window1()
        {
            InitializeComponent();
            SquadListBox_ContainsList();
        }

        private void SquadListBox_ContainsList()
        {
            SquadListBox.ItemsSource = _crudOpsForSquad.GetAllSquads();
            
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
            _crudOpsForSquad.SetSelectedSquad(SquadListBox.SelectedItem);
            if (_crudOpsForSquad.SelectedSquad != null)
            {
                SquadMemberListBox.ItemsSource = _crudOpsForSquadMembers.GetAllSquadMembers(_crudOpsForSquad.SelectedSquad.SquadId);
            }
        }
    }
}
