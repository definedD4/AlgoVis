using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.DataModel
{
    public abstract class ModelHolder
    {
        private OnLocals _onLocals = new OnLocals();
        private List<IModel> _models = new List<IModel>();

        public void ResetOnLocals()
        {
            _onLocals = new OnLocals();
        }

        public void ResetMetadata()
        {
            foreach (var model in _models)
            {
                model.ResetMetadata();
            }
        }

        public void FireOnLocalUpdates()
        {
            _onLocals.FireUpdates();
        }

        protected OnLocals On()
        {
            return _onLocals;
        }

        public void AddModel(IModel model)
        {
            _models.Add(model);
        }
    }
}
