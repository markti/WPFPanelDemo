using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class CirclePanel : EllipsePanel
    {
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(CirclePanel), new FrameworkPropertyMetadata(300d, new PropertyChangedCallback(OnRadiusPropertyChanged)));

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        private static void OnRadiusPropertyChanged(object sender, DependencyPropertyChangedEventArgs e) 
        {
            CirclePanel sendingObject = sender as CirclePanel;
            sendingObject.VerticalScalar = (double)e.NewValue;
            sendingObject.HorizontalScalar = (double)e.NewValue;
            sendingObject.InvalidateArrange();
        }

        public CirclePanel()
        {
            DefaultStyleKey = typeof(CirclePanel);
        }
    }
}
