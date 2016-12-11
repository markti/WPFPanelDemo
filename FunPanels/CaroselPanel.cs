using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FunPanels
{
    public class CaroselPanel : EllipsePanel
    {
        public static readonly DependencyProperty ItemScalarProperty = DependencyProperty.Register("ItemScalar", typeof(double), typeof(CaroselPanel), new FrameworkPropertyMetadata(0.1, new PropertyChangedCallback(OnItemScalarPropertyChanged)));
        public static readonly DependencyProperty AllowItemScalingProperty = DependencyProperty.Register("AllowItemScaling", typeof(bool), typeof(CaroselPanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnAllowItemScalingPropertyChanged)));

        public double ItemScalar
        {
            get { return (double)GetValue(ItemScalarProperty); }
            set { SetValue(ItemScalarProperty, value); }
        }
        public bool AllowItemScaling
        {
            get { return (bool)GetValue(AllowItemRotationProperty); }
            set { SetValue(AllowItemRotationProperty, value); }
        }
        private static void OnAllowItemScalingPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.InvalidateArrange();
        }
        private static void OnItemScalarPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.InvalidateArrange();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size baseSize = base.ArrangeOverride(finalSize);

            if (true)
            {
                for (int i = 0; i < this.Children.Count; i++)
                {
                    UIElement element = this.Children[i] as UIElement;
                    TransformGroup group = new TransformGroup();

                    // the closer you are to 0 and n the better
                    // the further you are from the median the bigger you get

                    int median = this.Children.Count / 2;
                    int distanceFromMedian = Math.Abs(i - median);
                    int distanceFromN = Math.Abs(Children.Count - i);
                    int distanceFromZero = i;
                    int weight = Math.Min(distanceFromN, distanceFromZero);


                    //double scalar = (double)i / (double)this.Children.Count;
                    double scalar = Math.Max(1 - (weight * ItemScalar), 0);
                    element.Opacity = scalar;
                    group.Children.Add(new ScaleTransform(scalar, scalar));

                    element.RenderTransform = group;
                    element.RenderTransformOrigin = new Point(0.5, 0.5);

                }
            }

            return baseSize;
        }
    }
}
