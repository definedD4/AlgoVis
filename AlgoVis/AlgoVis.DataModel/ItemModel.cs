using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AlgoVis.DataModel
{
    public class ItemModel : ReactiveObject
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        private readonly Subject<ItemPropertyChange> _propertyChangeSubject = new Subject<ItemPropertyChange>();

        [Reactive] public object Value { get; set; }

        public object this[string identifier]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(identifier))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(identifier));

                return _properties[identifier];
            }
            set
            {
                if (string.IsNullOrWhiteSpace(identifier))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(identifier));

                var oldValue = _properties[identifier];
                _properties[identifier] = value;
                OnPropertyChange(identifier, oldValue, value);
            }
        }

        public IObservable<object> ValuesObservable { get; }

        public IObservable<ItemPropertyChange> PropertyChangeObservable => _propertyChangeSubject;

        public ItemModel()
        {
            ValuesObservable = this.WhenAnyValue(x => x.Value);
        }

        private void OnPropertyChange(string property, object oldValue, object newValue)
        {
            _propertyChangeSubject.OnNext(new ItemPropertyChange(property, oldValue, newValue));
        }
    }
}
