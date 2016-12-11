using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class FermatSpiralPanel : AnimatingPanelBase
    {
        private bool _firstArrange = true;

        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(FermatSpiralPanel), new FrameworkPropertyMetadata(137.5d, new PropertyChangedCallback(OnAnglePropertyChanged)));
        public static readonly DependencyProperty ScalarProperty = DependencyProperty.Register("Scalar", typeof(double), typeof(FermatSpiralPanel), new FrameworkPropertyMetadata(50d, new PropertyChangedCallback(OnScalarPropertyChanged)));

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public double Scalar
        {
            get { return (double)GetValue(ScalarProperty); }
            set { SetValue(ScalarProperty, value); }
        }

        private static void OnAnglePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FermatSpiralPanel panel = sender as FermatSpiralPanel;
            panel.InvalidateArrange();
        }
        private static void OnScalarPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FermatSpiralPanel panel = sender as FermatSpiralPanel;
            panel.InvalidateArrange();
        }

        public FermatSpiralPanel()
        {
            AnimationCompleted += new RoutedEventHandler(FermatSpiralPanel_AnimationCompleted);
        }

        void FermatSpiralPanel_AnimationCompleted(object sender, RoutedEventArgs e)
        {
            _firstArrange = true;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int index = 0;
            foreach (UIElement child in this.Children)
            {
                double goldenAngle = 137.5;

                double r = Scalar * Math.Sqrt(index);
                double theta = index * Angle; // in degrees

                double centerX = finalSize.Width / 2; // ?
                double centerY = finalSize.Height / 2; // ?

                double x = centerX + r * Math.Cos(theta);
                double y = centerY + r * Math.Sin(theta);

                Rect childRect = new Rect();

                if (_firstArrange)
                {
                    childRect.X = 0;
                    childRect.Y = 1500;
                    childRect.Width = 100;
                    childRect.Height = 100;
                }
                else
                {
                    childRect.X = x;
                    childRect.Y = y;
                    childRect.Width = 100;
                    childRect.Height = 100;
                }
                SetElementLocation(child, childRect);

                if (_firstArrange && this.Children.Count > 0)
                {
                    _firstArrange = false;
                    this.InvalidateMeasure();
                }

                //child.Arrange(childRect);

                index++;
            }
            return base.ArrangeOverride(finalSize);
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in this.Children)
            {
                Size childSize = child.DesiredSize;
                child.Measure(childSize);
            }
            return base.MeasureOverride(availableSize);
        }
    }
}
