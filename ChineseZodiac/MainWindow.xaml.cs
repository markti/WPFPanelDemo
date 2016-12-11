using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ChineseZodiac.Model;

namespace ChineseZodiac
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel Model { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Model = new ViewModel();

            DataContext = Model;

        }

        private void FermatSpiralTemplate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            double angle = double.Parse(btn.Tag.ToString());
            FermatAngle.Value = angle;
        }
    }
}
