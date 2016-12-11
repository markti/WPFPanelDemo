using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ChineseZodiac.Model
{
    public class Zodiac
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Element Element { get; set; }
        public Side Side { get; set; }
        public int Trine { get; set; }
        public string ImageSource { get; set; }
    }

    public enum Side
    {
        Yin, Yang
    }

    public enum Element
    {
        Water, Wood, Metal, Fire
    }
}
