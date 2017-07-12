using AlgoVis.Core;
using AlgoVis.UI.Exceptions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.UI.AlgorithmActionParam
{
    public class AlgorithmActionParamViewModel : ReactiveObject
    {
        private readonly ActionParameter _parameter;

        [Reactive] public string Input { get; set; }

        public bool Valid { [ObservableAsProperty] get; }

        public object Value { [ObservableAsProperty] get; }

        public AlgorithmActionParamViewModel(ActionParameter parameter)
        {
            _parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));

            var converted = this
                .WhenAnyValue(x => x.Input)
                .Select(str => {
                    object ret = null;
                    try
                    {
                        ret = Convert(str, _parameter.Type);
                    }
                    catch (Exception ex)
                    {
                        return Tuple.Create<bool, object, Exception>(false, null, ex);
                    }
                    if(_parameter.Validator(ret))
                    {
                        return Tuple.Create<bool, object, Exception>(true, ret, null);
                    }
                    else
                    {
                        return Tuple.Create<bool, object, Exception>(false, null, new ParamValidationNotPassedException());
                    }
                });

            converted
                .Select(t => t.Item1)
                .ToPropertyEx(this, x => x.Valid);

            converted
                .Select(t => t.Item2)
                .ToPropertyEx(this, x => x.Value);

            /*converted
                .Select(t => t.Item3)
                .ToPropertyEx(this, x => x.Error);*/
        }

        private object Convert(string input, Type target)
        {
            if(target == typeof(string))
            {
                return input;
            }
            else if(target == typeof(int))
            {
                return int.Parse(input);
            }
            else if (target == typeof(float))
            {
                return float.Parse(input);
            }
            else if(target == typeof(double))
            {
                return double.Parse(input);
            }
            else
            {
                throw new ParamTypeNotSupportedException();
            }
        }
    }
}
