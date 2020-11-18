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

namespace SquadFinder3TierFrontEnd
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public CRUDoperationsForMembers _crudOps = new CRUDoperationsForMembers();


        public Window2()
        {
            InitializeComponent();
            MemberListBox_ContainsList();
        }

        private void MemberListBox_ContainsList()
        {
            MembersListBox.ItemsSource = _crudOps.GetAllMembers();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow homePage = new MainWindow();
            this.Visibility = Visibility.Hidden;
            homePage.Show();
        }
    }
}
