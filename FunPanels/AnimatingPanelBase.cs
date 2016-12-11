using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.Generic;

namespace FunPanels
{
    public class AnimatingPanelBase : Panel
    {
        #region Private Fields

        DispatcherTimer timer;
        Dictionary<UIElement, ElementState> states;
        double animatingCount = 0;

        #endregion

        #region Constructor

        public AnimatingPanelBase()
        {
            // make sure that the elements collection has been initialized
            states = new Dictionary<UIElement, ElementState>();
            this.Force = 1.0;
            this.Resistance = 0.25;
            this.Milliseconds = 30;
            this.SnapPrecision = 2.0;
            this.Randomness = 0.5;
            this.IsAnimationEnabled = true;
        }

        #endregion

        #region Dependency Properties

        #region Force (DependencyProperty)

        public double Force
        {
            get { return (double)GetValue(ForceProperty); }
            set { SetValue(ForceProperty, value); }
        }
        public static readonly DependencyProperty ForceProperty =
            DependencyProperty.Register("Force", typeof(double), typeof(AnimatingPanelBase), null);

        #endregion

        #region Resistance (DependencyProperty)

        public double Resistance
        {
            get { return (double)GetValue(ResistanceProperty); }
            set { SetValue(ResistanceProperty, value); }
        }
        public static readonly DependencyProperty ResistanceProperty =
            DependencyProperty.Register("Resistance", typeof(double), typeof(AnimatingPanelBase), null);

        #endregion

        #region Milliseconds (DependencyProperty)

        public double Milliseconds
        {
            get { return (double)GetValue(MillisecondsProperty); }
            set { SetValue(MillisecondsProperty, value); }
        }
        public static readonly DependencyProperty MillisecondsProperty =
            DependencyProperty.Register("Milliseconds", typeof(double), typeof(AnimatingPanelBase), null);

        #endregion

        #region SnapPrecision (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public double SnapPrecision
        {
            get { return (double)GetValue(SnapPrecisionProperty); }
            set { SetValue(SnapPrecisionProperty, value); }
        }
        public static readonly DependencyProperty SnapPrecisionProperty =
            DependencyProperty.Register("SnapPrecision", typeof(double), typeof(AnimatingPanelBase), null);

        #endregion

        #region Randomness (DependencyProperty)

        public double Randomness
        {
            get { return (double)GetValue(RandomnessProperty); }
            set { SetValue(RandomnessProperty, value); }
        }
        public static readonly DependencyProperty RandomnessProperty =
            DependencyProperty.Register("Randomness", typeof(double), typeof(AnimatingPanelBase), null);

        #endregion

        #region IsAnimationEnabled (DependencyProperty)

        public bool IsAnimationEnabled
        {
            get { return (bool)GetValue(IsAnimationEnabledProperty); }
            set { SetValue(IsAnimationEnabledProperty, value); }
        }
        public static readonly DependencyProperty IsAnimationEnabledProperty =
            DependencyProperty.Register("IsAnimationEnabled", typeof(bool), typeof(AnimatingPanelBase), null);

        #endregion

        #endregion

        #region Events

        #region AnimationCompleted

        public event RoutedEventHandler AnimationCompleted;

        private void RaiseAnimationCompleted()
        {
            StopTimer();

            if (AnimationCompleted != null)
            {
                AnimationCompleted(this, new RoutedEventArgs());
            }
        }

        #endregion

        #endregion

        #region Private Methods

        bool isTimerStarted = false;
        private void StartTimer()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds((int)1000 / 60);
                //timer.Interval = TimeSpan.FromMilliseconds(this.Milliseconds);
                timer.Tick += new EventHandler(timer_Tick);
            }

            if (!isTimerStarted)
            {
                timer.Start();
                isTimerStarted = true;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateElementLocations();
        }

        private void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                isTimerStarted = false;
            }
        }

        protected void SetElementLocation(UIElement e, Rect finalRect)
        {
            SetElementLocation(e, finalRect, true);
        }

        private void WriteDebugIfIndex(UIElement e, int index, string msg)
        {
            //if (e is FrameworkElement)
            //{
            //    FrameworkElement f = (FrameworkElement)e;
            //    if (f.Parent is CataloguePanel)
            //    {
            //        CataloguePanel p = f.Parent as CataloguePanel;
            //        int i = p.Children.IndexOf(e);

            //        if (index == i || index == -1)
            //        {
            //            Debug.WriteLine(i + ":" + msg);
            //        }
            //    }
            //}

        }

        protected void SetElementLocation(UIElement e, Rect finalRect, bool isAnimated)
        {

            // update the element's state
            ElementState state = null;

            if (states.ContainsKey(e))
            {
                state = states[e];
            }
            else
            {
                state = new ElementState(finalRect, this.Randomness);
                states.Add(e, state);
            }

            // set the final rectangle and kick of the timer

            if (isAnimated && IsAnimationEnabled)
            {
                if (!state.NeedsArrange)
                {
                    state.NeedsArrange = true;
                    animatingCount++;
                }

                state.TargetRect = finalRect;

                // make sure that the timer is running
                StartTimer();
            }
            else
            {
                e.Arrange(finalRect);
                state.CurrentRect = finalRect;

                if (state.NeedsArrange)
                {
                    state.NeedsArrange = false;
                    animatingCount--;
                }
            }
        }

        private void UpdateElementLocations()
        {
            ElementState state;

            for (int i = 0; i < Children.Count; i++)
            {
                UIElement element = Children[i];
                if (states.ContainsKey(element))
                {
                    state = states[element];
                    if (UpdateElementLocation(element, state))
                    {
                        element.Arrange(state.CurrentRect);
                    }
                }
            }
            //foreach (UIElement element in Children)
            //{
            //    state = states[element];
            //    if (UpdateElementLocation(element, state))
            //    {
            //        element.Arrange(state.CurrentRect);
            //    }
            //}
        }

        private bool UpdateElementLocation(UIElement child, ElementState state)
        {
            if (state == null)
            {
                return false;
            }
            else if (state.NeedsArrange)
            {
                // get the values we will need to update the element
                double force = this.Force;
                double resistance = this.Resistance;
                double seconds = 1.0 / this.Milliseconds;

                //look at location
                Point newCurrentLocation;
                Vector newLocationVelocity;
                bool locationChanged = RecalculateCurrentPoint(ToPoint(state.CurrentRect), ToPoint(state.TargetRect), state.LocationVelocity,
                    seconds, resistance, force * state.AttractionMultiplier,
                    out newCurrentLocation, out newLocationVelocity);

                //look at size
                Point newCurrentSize;
                Vector newSizeVelocity;
                bool sizeChanged = RecalculateCurrentPoint(GetPointFromSize(ToSize(state.CurrentRect)), GetPointFromSize(ToSize(state.TargetRect)),
                    state.SizeVelocity,
                    seconds, resistance, force * state.AttractionMultiplier,
                    out newCurrentSize, out newSizeVelocity);

                if (locationChanged || sizeChanged)
                {
                    state.CurrentRect.X = newCurrentLocation.X;
                    state.CurrentRect.Y = newCurrentLocation.Y;
                    state.LocationVelocity = newLocationVelocity;

                    Size newSizeFromPoint = GetSizeFromPoint(newCurrentSize);

                    double newWidth = Math.Max(newSizeFromPoint.Width, child.DesiredSize.Width);
                    double newHeight = Math.Max(newSizeFromPoint.Height, child.DesiredSize.Height);

                    state.CurrentRect.Width = newWidth;
                    state.CurrentRect.Height = newHeight;

                    state.SizeVelocity = newSizeVelocity;

                    return true;
                }
                else
                {
                    state.NeedsArrange = false;
                    animatingCount--;

                    if (animatingCount == 0)
                    {
                        this.RaiseAnimationCompleted();
                    }

                    return false;
                }
            }

            return false;
        }

        private static Point ToPoint(Rect r)
        {
            return new Point(r.X, r.Y);
        }


        private static Size ToSize(Rect r)
        {
            return new Size(r.Width, r.Height);
        }

        private static void SetSize(Rect r, Size s)
        {
            r.Width = s.Width;
            r.Height = s.Height;
        }

        private static Point GetPointFromSize(Size size)
        {
            return new Point(size.Width, size.Height);
        }

        private static Size GetSizeFromPoint(Point point)
        {
            return new Size(Math.Max(point.X, 0), Math.Max(point.Y, 0));
        }

        private bool RecalculateCurrentPoint(Point current, Point target, Vector velocity, double seconds, double dampening, double attractionFactor,
            out Point newCurrentPoint, out Vector newVelocity)
        {
            if (current != target)
            {
                Vector diff = new Vector(target.X - current.X, target.Y - current.Y);

                if (diff.Length > this.SnapPrecision || velocity.Length > this.SnapPrecision)
                {
                    velocity.X *= (1 - dampening);
                    velocity.Y *= (1 - dampening);

                    velocity += diff;

                    Vector delta = velocity * seconds * attractionFactor;

                    double maxVelocity = 600;
                    delta *= (delta.Length > maxVelocity) ? (maxVelocity / delta.Length) : 1;

                    current.X += delta.X;
                    current.Y += delta.Y;

                    newCurrentPoint = current;
                    newVelocity = velocity;
                    return true;
                }
                else
                {
                    newCurrentPoint = target;
                    newVelocity = new Vector(0, 0);
                    return true;
                }
            }
            else
            {
                newCurrentPoint = current;
                newVelocity = velocity;
                return false;
            }
        }

        #endregion

        #region Public Methods

        public Rect GetElementRect(UIElement child)
        {
            if (states.ContainsKey(child))
            {
                return states[child].CurrentRect;
            }
            else
            {
                return Rect.Empty;
            }
        }

        #endregion

        #region ElementState (Private Class)

        private class ElementState
        {
            public static Random _Random = new Random();

            public ElementState(Rect targetRect, double randomness)
            {
                CurrentRect = new Rect(0, 0, targetRect.Width, targetRect.Height);
                TargetRect = targetRect;
                LocationVelocity = new Vector(0, 0);

                SizeVelocity = new Vector(0, 0);

                AttractionMultiplier = (_Random.NextDouble() * randomness) + .4;
                NeedsArrange = false;
            }

            public Rect TargetRect;
            public Rect CurrentRect;
            public Vector LocationVelocity;
            public Vector SizeVelocity;
            public double AttractionMultiplier;
            public bool NeedsArrange;
        }

        #endregion
    }

    public struct Vector
    {
        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        internal double _x;
        internal double _y;

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return ((vector1.X == vector2.X) && (vector1.Y == vector2.Y));
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        public static bool Equals(Vector vector1, Vector vector2)
        {
            return (vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y));
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is Vector))
            {
                return false;
            }
            Vector vector = (Vector)o;
            return Equals(this, vector);
        }

        public bool Equals(Vector value)
        {
            return Equals(this, value);
        }

        public override int GetHashCode()
        {
            return (this.X.GetHashCode() ^ this.Y.GetHashCode());
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public double Length
        {
            get
            {
                return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
            }
        }
        public double LengthSquared
        {
            get
            {
                return ((this.X * this.X) + (this.Y * this.Y));
            }
        }
        public void Normalize()
        {
            this = (Vector)(this / Math.Max(Math.Abs(this.X), Math.Abs(this.Y)));
            this = (Vector)(this / this.Length);
        }

        public static double CrossProduct(Vector vector1, Vector vector2)
        {
            return ((vector1.X * vector2.Y) - (vector1.Y * vector2.X));
        }

        public static double AngleBetween(Vector vector1, Vector vector2)
        {
            double y = (vector1.X * vector2.Y) - (vector2.X * vector1.Y);
            double x = (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
            return (Math.Atan2(y, x) * 57.295779513082323);
        }

        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y);
        }

        public void Negate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        public static Point operator +(Vector vector, Point point)
        {
            return new Point(point.X + vector.X, point.Y + vector.Y);
        }

        public static Point Add(Vector vector, Point point)
        {
            return new Point(point.X + vector.X, point.Y + vector.Y);
        }

        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector Multiply(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector operator *(double scalar, Vector vector)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector Multiply(double scalar, Vector vector)
        {
            return new Vector(vector.X * scalar, vector.Y * scalar);
        }

        public static Vector operator /(Vector vector, double scalar)
        {
            return (Vector)(vector * (1.0 / scalar));
        }

        public static Vector Divide(Vector vector, double scalar)
        {
            return (Vector)(vector * (1.0 / scalar));
        }

        public static double operator *(Vector vector1, Vector vector2)
        {
            return ((vector1.X * vector2.X) + (vector1.Y * vector2.Y));
        }

        public static double Multiply(Vector vector1, Vector vector2)
        {
            return ((vector1.X * vector2.X) + (vector1.Y * vector2.Y));
        }

        public static double Determinant(Vector vector1, Vector vector2)
        {
            return ((vector1.X * vector2.Y) - (vector1.Y * vector2.X));
        }

        public static explicit operator Size(Vector vector)
        {
            return new Size(Math.Abs(vector.X), Math.Abs(vector.Y));
        }

        public static explicit operator Point(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }
    }
}
