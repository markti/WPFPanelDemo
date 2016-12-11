using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunPanels
{
    /// <summary>
    /// </summary>
    public class StackPanel : AnimatingPanelBase
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            int index = 0;
            foreach (UIElement child in this.Children)
            {
                Rect childRect = new Rect();
                childRect.X = 0; // 100 * index;
                childRect.Y = 100 * index;
                childRect.Width = 100;
                childRect.Height = 100;

                SetElementLocation(child, childRect);
                //child.Arrange(childRect); // Non-Animating Way

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