using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class SinePanel : AnimatingPanelBase
    {
        public static readonly DependencyProperty AllowItemRotationProperty = DependencyProperty.Register("AllowItemRotation", typeof(bool), typeof(SinePanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnAllowItemRotationPropertyChanged)));


        public bool AllowItemRotation
        {
            get { return (bool)GetValue(AllowItemRotationProperty); }
            set { SetValue(AllowItemRotationProperty, value); }
        }
        private static void OnAllowItemRotationPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.InvalidateArrange();
        }


        public static readonly DependencyProperty ItemRotationOffsetProperty = DependencyProperty.Register("ItemRotationOffset", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(270d, new PropertyChangedCallback(OnItemRotatePropertyChanged)));
        public double ItemRotationOffset
        {
            get { return (double)GetValue(ItemRotationOffsetProperty); }
            set { SetValue(ItemRotationOffsetProperty, value); }
        }

        private static void OnItemRotatePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.InvalidateArrange();
        }


        public static readonly DependencyProperty StartPositionProperty = DependencyProperty.Register("StartPosition", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(0d, new PropertyChangedCallback(OnStartPositionPropertyChanged)));
        public static readonly DependencyProperty AngleIncrementProperty = DependencyProperty.Register("AngleIncrement", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(0d, new PropertyChangedCallback(OnAngleIncrementPropertyChanged)));
        public static readonly DependencyProperty AngularFrequencyProperty = DependencyProperty.Register("AngularFrequency", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(1d, new PropertyChangedCallback(OnAngularFrequencyPropertyChanged)));
        public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register("Amplitude", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(1d, new PropertyChangedCallback(OnAmplitudePropertyChanged)));
        public static readonly DependencyProperty LengthProperty = DependencyProperty.Register("Length", typeof(double), typeof(SinePanel), new FrameworkPropertyMetadata(360d, new PropertyChangedCallback(OnLengthPropertyChanged)));

        public double StartPosition
        {
            get { return (double)GetValue(StartPositionProperty); }
            set { SetValue(StartPositionProperty, value); }
        }
        public double AngleIncrement
        {
            get { return (double)GetValue(AngleIncrementProperty); }
            set { SetValue(AngleIncrementProperty, value); }
        }
        public double AngularFrequency
        {
            get { return (double)GetValue(AngularFrequencyProperty); }
            set { SetValue(AngularFrequencyProperty, value); }
        }
        public double Amplitude
        {
            get { return (double)GetValue(AmplitudeProperty); }
            set { SetValue(AmplitudeProperty, value); }
        }
        public double Length
        {
            get { return (double)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }

        private static void OnStartPositionPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }
        private static void OnAngleIncrementPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }
        private static void OnAngularFrequencyPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }
        private static void OnAmplitudePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }
        private static void OnLengthPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double angleIncrement = Length / this.Children.Count;

            for (int i = 0; i < this.Children.Count; i++)
            {
                double centerX = finalSize.Width / 2; // ?
                double centerY = finalSize.Height / 2; // ?

                double angleDeg = (StartPosition + (i * angleIncrement));
                double angle = angleDeg * (Math.PI / 180.0);
                UIElement element = this.Children[i] as UIElement;

                double x = i * 100;
                if (HorizontalAlignment == HorizontalAlignment.Stretch)
                {
                    x = (finalSize.Width / Children.Count) * i;
                }
                double y = centerY + Amplitude * Math.Sin(AngularFrequency * angle);

                double rotateAngle = 0;
                if (AllowItemRotation)
                {
                    rotateAngle = ItemRotationOffset + angleDeg;
                }

                element.RenderTransform = new System.Windows.Media.RotateTransform(rotateAngle);
                element.RenderTransformOrigin = new Point(0, 0);

                Rect r = new Rect(x, y, finalSize.Width, finalSize.Height);

                //element.Arrange(r);
                SetElementLocation(element, r);
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}