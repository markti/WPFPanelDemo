using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class EllipsePanel : AnimatingPanelBase
    {
        public static readonly DependencyProperty HorizontalScalarProperty = DependencyProperty.Register("HorizontalScalar", typeof(double), typeof(EllipsePanel), new FrameworkPropertyMetadata(300d, new PropertyChangedCallback(OnHorizontalScalarPropertyChanged)));
        public static readonly DependencyProperty VerticalScalarProperty = DependencyProperty.Register("VerticalScalar", typeof(double), typeof(EllipsePanel), new FrameworkPropertyMetadata(300d, new PropertyChangedCallback(OnVerticalScalarPropertyChanged)));
        public static readonly DependencyProperty ItemRotationOffsetProperty = DependencyProperty.Register("ItemRotationOffset", typeof(double), typeof(EllipsePanel), new FrameworkPropertyMetadata(270d, new PropertyChangedCallback(OnItemRotatePropertyChanged)));
        public static readonly DependencyProperty AllowItemRotationProperty = DependencyProperty.Register("AllowItemRotation", typeof(bool), typeof(EllipsePanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnAllowItemRotationPropertyChanged)));


        public bool AllowItemRotation
        {
            get { return (bool)GetValue(AllowItemRotationProperty); }
            set { SetValue(AllowItemRotationProperty, value); }
        }

        public double ItemRotationOffset
        {
            get { return (double)GetValue(ItemRotationOffsetProperty); }
            set { SetValue(ItemRotationOffsetProperty, value); }
        }
        public double HorizontalScalar
        {
            get { return (double)GetValue(HorizontalScalarProperty); }
            set { SetValue(HorizontalScalarProperty, value); }
        }
        public double VerticalScalar
        {
            get { return (double)GetValue(VerticalScalarProperty); }
            set { SetValue(VerticalScalarProperty, value); }
        }

        private static void OnHorizontalScalarPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EllipsePanel panel = sender as EllipsePanel;
            panel.InvalidateArrange();
        }
        private static void OnVerticalScalarPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EllipsePanel panel = sender as EllipsePanel;
            panel.InvalidateArrange();
        }
        private static void OnItemRotatePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EllipsePanel panel = sender as EllipsePanel;
            panel.InvalidateArrange();
        }
        private static void OnAllowItemRotationPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            EllipsePanel panel = sender as EllipsePanel;
            panel.InvalidateArrange();
        }

        public EllipsePanel()
        {
            DefaultStyleKey = typeof(EllipsePanel);
        }

        bool adjustRotation = true;

        protected override Size ArrangeOverride(Size finalSize)
        {
            double count = 1;
            if(this.Children.Count != 0) 
            {
                count = Children.Count;
            }
            double angleIncrement = 360 / count;
            for (int i = 0; i < this.Children.Count; i++)
            {
                double centerX = finalSize.Width / 2; // ?
                double centerY = finalSize.Height / 2; // ?
                centerX = 0;
                centerY = 0;

                double angleDeg = -90 + i * angleIncrement;
                double angle = angleDeg * (Math.PI / 180.0);
                UIElement element = this.Children[i] as UIElement;
                double x = centerX + HorizontalScalar * Math.Cos(angle);
                double y = centerY + VerticalScalar * Math.Sin(angle);

                Rect r = new Rect(x, y, finalSize.Width, finalSize.Height);

                double rotateAngle = 0;
                if (AllowItemRotation)
                {
                    rotateAngle = ItemRotationOffset + angleDeg;
                }

                element.RenderTransform = new System.Windows.Media.RotateTransform(rotateAngle);
                element.RenderTransformOrigin = new Point(0.5, 0.5);

                //element.Arrange(r);

                SetElementLocation(element, r);
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}
