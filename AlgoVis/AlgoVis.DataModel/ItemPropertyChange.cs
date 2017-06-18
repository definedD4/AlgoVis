using System;

namespace AlgoVis.DataModel
{
    public sealed class ItemPropertyChange
    {
        public ItemPropertyChange(string property, object oldValue, object newValue)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(property));

            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public string Property { get; }
        public object OldValue { get; }
        public object NewValue { get; }
    }
}