using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AlgoVis.Controls
{
    public class AnimatedPanel : Panel
    {
        public AnimatedPanel()
        {

        }

        public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register(
            "AnimationDuration", typeof(TimeSpan), typeof(AnimatedPanel), new PropertyMetadata(default(TimeSpan)));

        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan) GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.RegisterAttached(
            "HorizontalOffset", typeof(double), typeof(AnimatedPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentArrange));

        public static void SetHorizontalOffset(DependencyObject element, double value)
        {
            element.SetValue(HorizontalOffsetProperty, value);
        }

        public static double GetHorizontalOffset(DependencyObject element)
        {
            return (double) element.GetValue(HorizontalOffsetProperty);
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            AssignOffsets(visualAdded);
        }

        private void AssignOffsets(DependencyObject recentlyAdded = null)
        {
            double offset = 0d;
            foreach (UIElement child in InternalChildren)
            {
                if (ReferenceEquals(child, recentlyAdded))
                {
                    SetHorizontalOffset(child, offset);
                }
                else
                {
                    child.BeginAnimation(HorizontalOffsetProperty, new DoubleAnimation(offset, AnimationDuration));
                }

                offset += child.DesiredSize.Width;
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            double maxHeight = 0d;
            double width = 0d;
            
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(new Size(double.PositiveInfinity, constraint.Width));

                maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
                width += child.DesiredSize.Width;
            }

            AssignOffsets();

            return new Size(width, maxHeight);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Arrange(new Rect(new Point(GetHorizontalOffset(child), 0d), new Size(child.DesiredSize.Width, arrangeBounds.Height)));
            }

            return arrangeBounds;
        }
    }
}