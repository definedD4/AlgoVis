using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AlgoVis.Controls
{
    public class IndexPanel : Panel
    {
        public IndexPanel()
        {

        }

        public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register(
            "AnimationDuration", typeof(TimeSpan), typeof(IndexPanel), new PropertyMetadata(TimeSpan.Zero));

        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan) GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.RegisterAttached(
            "HorizontalOffset", typeof(double), typeof(IndexPanel), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsParentArrange));

        public static void SetHorizontalOffset(DependencyObject element, double value)
        {
            element.SetValue(HorizontalOffsetProperty, value);
        }

        public static double GetHorizontalOffset(DependencyObject element)
        {
            return (double) element.GetValue(HorizontalOffsetProperty);
        }

        public static readonly DependencyProperty IndexProperty = DependencyProperty.RegisterAttached(
            "Index", typeof(int), typeof(IndexPanel), new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsParentArrange));

        public static void SetIndex(DependencyObject element, int value)
        {
            element.SetValue(IndexProperty, value);
        }

        public static int GetIndex(DependencyObject element)
        {
            return (int) element.GetValue(IndexProperty);
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            AssignOffsets(visualAdded);
        }

        private void AssignOffsets(DependencyObject recentlyAdded = null)
        {
            var sortedChildren = Children.Cast<UIElement>().ToList();
            sortedChildren.Sort((a, b) => GetIndex(a) - GetIndex(b));

            double offset = 0d;
            foreach (UIElement child in sortedChildren)
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
            AssignOffsets();

            foreach (UIElement child in InternalChildren)
            {
                child.Arrange(new Rect(new Point(GetHorizontalOffset(child), 0d), new Size(child.DesiredSize.Width, arrangeBounds.Height)));
            }

            return arrangeBounds;
        }
    }
}