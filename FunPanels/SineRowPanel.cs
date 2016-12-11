using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class SineRowPanel : SinePanel
    {
        public static readonly DependencyProperty OccilateProperty = DependencyProperty.Register("Occilate", typeof(bool), typeof(SineRowPanel), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnOccilatePropertyChanged)));

        public bool Occilate
        {
            get { return (bool)GetValue(OccilateProperty); }
            set { SetValue(OccilateProperty, value); }
        }
        private static void OnOccilatePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }
        
        public static readonly DependencyProperty RowLengthScalarProperty = DependencyProperty.Register("RowLengthScalar", typeof(double), typeof(SineRowPanel), new FrameworkPropertyMetadata(0.5d, new PropertyChangedCallback(OnRowLengthScalarPropertyChanged)));

        public double RowLengthScalar
        {
            get { return (double)GetValue(RowLengthScalarProperty); }
            set { SetValue(RowLengthScalarProperty, value); }
        }
        private static void OnRowLengthScalarPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SinePanel panel = sender as SinePanel;
            panel.InvalidateArrange();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Debug.WriteLine("Arrange Pass");
            bool done = false;
            int itemIndex = 0;
            double centerX = finalSize.Width / 2;
            double centerY = finalSize.Height / 2;

            double currentTop = centerY;
            double currentWidth = finalSize.Width;
            double originalWidth = currentWidth;
            int originalItemsPerRow = (int)(currentWidth / 100.0);
            double originalAngleIncrement = Length / originalItemsPerRow;

            int rowCount = 0;
            double currentStartPosition = StartPosition;
            double currentLength = Length;

            while (!done)
            {

                bool isEven = rowCount % 2 == 0;
                int multiplier = isEven ? 1 : -1;
                int d = (rowCount + 1) / 2;
                int dx = (rowCount + 1) / 2 * multiplier;
                if (Occilate)
                {
                    currentTop = centerY + 125 * dx;
                }
                else
                {
                    currentTop = centerY + 125 * rowCount;
                }

                currentWidth = originalWidth * Math.Pow(RowLengthScalar, d);

                //currentStartPosition *= 1.1;
                //currentLength *= 0.90;


                int actualItemsPerRow = (int)(currentWidth / 100.0);

                int itemsPerRow = actualItemsPerRow;
                if (itemsPerRow == 0)
                {
                    itemsPerRow = 1;
                }
                Debug.WriteLine("Items Per Row: " + itemsPerRow);

                int lastItem = itemIndex + itemsPerRow;
                int remainingItems = this.Children.Count - lastItem;
                Debug.WriteLine("Top=" + currentTop + ", Item Count=" + itemsPerRow);
                if (remainingItems <= 0)
                {
                    itemsPerRow += remainingItems;
                    done = true;
                }

                int itemDifference = itemsPerRow - originalItemsPerRow;
                double horizontalOffset = 0;
                if (itemDifference < 0)
                {
                    double lengthReduction = itemDifference * originalAngleIncrement;
                    horizontalOffset = -1.0 * itemDifference / 2.0;
                    //currentLength += lengthReduction;
                    //currentStartPosition += (horizontalOffset * originalAngleIncrement);
                }

                double angleIncrement = currentLength / actualItemsPerRow;
                angleIncrement = originalAngleIncrement;

                for (int rowIndex = 0; rowIndex < itemsPerRow; rowIndex++)
                {
                    UIElement element = this.Children[itemIndex] as UIElement;
                    double angle = (currentStartPosition + ((rowIndex + horizontalOffset) * angleIncrement));
                    angle = angle * (Math.PI / 180.0); // convert to rad

                    double x = (rowIndex + horizontalOffset) * 100;
                    double y = currentTop + Amplitude * Math.Sin(AngularFrequency * angle);
                    Rect r = new Rect(x, y, finalSize.Width, finalSize.Height);

                    SetElementLocation(element, r);

                    itemIndex++;
                }

                rowCount++;
            }

            return finalSize;
        }
    }
}
