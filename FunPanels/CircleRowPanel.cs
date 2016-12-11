using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FunPanels
{
    public class CircleRowPanel : CirclePanel
    {
        //public static readonly DependencyProperty OccilateProperty = DependencyProperty.Register("Occilate", typeof(bool), typeof(SineRowPanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnOccilatePropertyChanged)));

        //public bool Occilate
        //{
        //    get { return (bool)GetValue(OccilateProperty); }
        //    set { SetValue(OccilateProperty, value); }
        //}
        //private static void OnOccilatePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    SinePanel panel = sender as SinePanel;
        //    panel.InvalidateArrange();
        //}
        private double CalculateAverageItemWidth()
        {
            double total = 0;
            foreach (UIElement uie in this.Children)
            {
                total += uie.DesiredSize.Width;
            }
            return total / this.Children.Count;
        }
        private double CalculateAverageItemHeight()
        {
            double total = 0;
            foreach (UIElement uie in this.Children)
            {
                total += uie.DesiredSize.Height;
            }
            return total / this.Children.Count;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Dictionary<int, List<UIElement>> rowedElements = new Dictionary<int, List<UIElement>>();

            Debug.WriteLine("Arrange Pass");
            double currentRadius = Radius;

            bool done = false;
            int itemIndex = 0;            
            double centerX = finalSize.Width / 2; // ?
            double centerY = finalSize.Height / 2; // ?
            centerX = 0;
            centerY = 0;
            int r = 0;

            while (!done)
            {
                rowedElements.Add(r, new List<UIElement>());

                double avgWidth = CalculateAverageItemWidth() * 1.25;
                //avgWidth = 150.0;

                // calculate the number of items for the current radius
                double itemsPerQuadrant = currentRadius / avgWidth;
                int actualItemsPerRow = (int)(itemsPerQuadrant * 4 * 1.75);
                int itemsPerRow = actualItemsPerRow;
                
                int lastItem = itemIndex + itemsPerRow;
                int remainingItems = this.Children.Count - lastItem; // 10 - 8
                Debug.WriteLine("R=" + currentRadius + ", Item COunt=" + itemsPerRow);
                if (remainingItems < 0)
                {
                    itemsPerRow += remainingItems;
                    done = true;
                }
                
                for (int rowIndex = 0; rowIndex < itemsPerRow; rowIndex++)
                {
                    double angleIncrement = 360.0 / actualItemsPerRow;
                    double angleDeg = rowIndex * angleIncrement;
                    double angle = angleDeg * (Math.PI / 180.0);
                    UIElement element = this.Children[itemIndex] as UIElement;
                    double x = centerX + currentRadius * Math.Cos(angle);
                    double y = centerY + currentRadius * Math.Sin(angle);

                    double rotateAngle = 0;
                    if (AllowItemRotation)
                    {
                        rotateAngle = ItemRotationOffset + angleDeg;
                    }

                    rowedElements[r].Add(element);
                    TransformGroup tg = new TransformGroup();
                    tg.Children.Add(new RotateTransform(rotateAngle));

                    element.RenderTransform = tg;
                        
                    element.RenderTransformOrigin = new Point(0.5, 0.5);

                    Rect childRect = new Rect(x, y, finalSize.Width, finalSize.Height);
                    SetElementLocation(element, childRect);
                    //element.Arrange(childRect);

                    itemIndex++;
                }

                double avgHeight = CalculateAverageItemHeight() * 1.25;
                currentRadius += avgHeight;
                r++; // row count
            }

            //double scalar = 1.0 / (double)r;
            //for (int i=0; i < rowedElements.Count; i++)
            //{
            //    List<UIElement> list = rowedElements.Values.ElementAt(i);
            //    foreach (UIElement item in list)
            //    {
            //        double s = scalar * (i+1);
            //        TransformGroup tg = item.RenderTransform as TransformGroup;
            //        tg.Children.Add(new ScaleTransform(s, s));
            //    }
            //}

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
        }
    }
}
