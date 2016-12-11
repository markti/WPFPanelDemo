using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    public class GridPanel : AnimatingPanelBase
    {
        public static readonly DependencyProperty CellHeightProperty = DependencyProperty.Register("CellHeight", typeof(double), typeof(GridPanel), new FrameworkPropertyMetadata(100d, new PropertyChangedCallback(OnCellHeightPropertyChanged)));
        public static readonly DependencyProperty CellWidthProperty = DependencyProperty.Register("CellWidth", typeof(double), typeof(GridPanel), new FrameworkPropertyMetadata(100d, new PropertyChangedCallback(OnCellWidthPropertyChanged)));

        public double CellHeight
        {
            get { return (double)GetValue(CellHeightProperty); }
            set { SetValue(CellHeightProperty, value); }
        }
        public double CellWidth
        {
            get { return (double)GetValue(CellWidthProperty); }
            set { SetValue(CellWidthProperty, value); }
        }

        private static void OnCellHeightPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GridPanel p = sender as GridPanel;
            p.InvalidateArrange();
        }

        private static void OnCellWidthPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GridPanel p = sender as GridPanel;
            p.InvalidateArrange();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Debug.WriteLine("Arrange Pass");
            //double currentRadius = Radius;

            bool done = false;
            int itemIndex = 0;
            double centerX = 0; // ?
            double centerY = 200; // ?
            int rowIndex = 0;

            while (!done)
            {

                // calculate the number of items for the current radius
                //double itemsPerQuadrant = currentRadius / 100.0;
                //int actualItemsPerRow = (int)(itemsPerQuadrant * 4 * 1.75);
                int itemsPerRow = (int)(finalSize.Width / 100.0);

                int lastItem = itemIndex + itemsPerRow;
                int remainingItems = this.Children.Count - lastItem; // 10 - 8
                //Debug.WriteLine("R=" + currentRadius + ", Item COunt=" + itemsPerRow);
                if (remainingItems < 0)
                {
                    itemsPerRow += remainingItems;
                    done = true;
                }

                for (int colIndex = 0; colIndex < itemsPerRow; colIndex++)
                {
                    UIElement element = this.Children[itemIndex] as UIElement;
                    double x = centerX + colIndex * 100;
                    double y = centerY + rowIndex * 100;

                    Rect childRect = new Rect(x, y, finalSize.Width, finalSize.Height);
                    SetElementLocation(element, childRect);
                    //element.Arrange(childRect);

                    itemIndex++;
                }

                rowIndex++;
            }

            return finalSize;
        }
    }
}
