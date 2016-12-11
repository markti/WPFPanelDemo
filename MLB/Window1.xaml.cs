using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MLB.Model;

namespace MLB
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ViewModel vm = new ViewModel();

        public Window1()
        {
            InitializeComponent();
            DataContext = vm;
        }


        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Storyboard sb3 = this.FindResource("Storyboard2") as Storyboard;
            sb3.Begin(this);

            Storyboard sb = teamList.FindResource("Storyboard1") as Storyboard;
            Grid g = VisualTreeHelper.GetChild(teamList, 0) as Grid;
            sb.Begin(g);

            Storyboard sb2 = infoList.FindResource("Storyboard2") as Storyboard;
            Grid g2 = VisualTreeHelper.GetChild(infoList, 0) as Grid;
            sb2.Begin(g2);

            vm.SelectedTeam = (sender as Grid).DataContext as BaseballTeam;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            TeamInfo ti = (sender as Grid).DataContext as TeamInfo;

            if (ti.ImagePath.Contains("Exit"))
            {

                Storyboard sb3 = this.FindResource("Storyboard1") as Storyboard;
                sb3.Begin(this);

                Storyboard sb = teamList.FindResource("Storyboard2") as Storyboard;
                Grid g = VisualTreeHelper.GetChild(teamList, 0) as Grid;
                sb.Begin(g);

                Storyboard sb2 = infoList.FindResource("Storyboard1") as Storyboard;
                Grid g2 = VisualTreeHelper.GetChild(infoList, 0) as Grid;
                sb2.Begin(g2);

                Storyboard sb4 = playerList.FindResource("Storyboard1") as Storyboard;
                Grid g3 = VisualTreeHelper.GetChild(playerList, 0) as Grid;
                sb4.Begin(g3);

            }
            else if (ti.ImagePath.Contains("Ambulance"))
            {

                Storyboard sb3 = playerList.FindResource("Storyboard2") as Storyboard;
                Grid g3 = VisualTreeHelper.GetChild(playerList, 0) as Grid;
                sb3.Begin(g3);
            }
        }
    }
}
