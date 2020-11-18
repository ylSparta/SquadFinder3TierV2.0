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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FunctionalityForSquadFinder;
using SquadFinder3Tier;

namespace SquadFinder3TierFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CRUDoperations _crudOps = new CRUDoperations();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void SquadPageButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 squadsPage = new Window1();
            this.Visibility = Visibility.Hidden;
            squadsPage.Show();
        }

        private void MemberPageButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 membersPage = new Window2();
            this.Visibility = Visibility.Hidden;
            membersPage.Show();
        }

        private void MatchRequestPageButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 matchRequestPage = new Window3();
            this.Visibility = Visibility.Hidden;
            matchRequestPage.Show();
        }
    }
}
