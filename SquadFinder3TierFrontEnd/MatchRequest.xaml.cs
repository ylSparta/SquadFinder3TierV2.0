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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public CRUDoperations _crudOps = new CRUDoperations();

        public Window3()
        {
            InitializeComponent();
        }

        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow homePage = new MainWindow();
            this.Visibility = Visibility.Hidden;
            homePage.Show();
        }
    }
}
