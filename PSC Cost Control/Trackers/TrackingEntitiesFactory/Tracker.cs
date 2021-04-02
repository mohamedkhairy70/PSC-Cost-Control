using PSC_Cost_Control.Factories.PersistantCruds;
using PSC_Cost_Control.Helper.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Factories.TrackingEntitiesFactory
{
    public  class Tracker<T> where T:IHasId
    {
        private IDictionary<int, T> _base;
        public  LinkedList<T> _added;
        private LinkedList<T> _deleted;
        private LinkedList<T> _udated;
        private IPersistent<T> _persistent;
        public Tracker(IPersistent<T> persistent,IEnumerable<T> origin)
        {
            _persistent = persistent;
            _base = origin.ToDictionary(o => o.Id);
            _base = new Dictionary<int,T>();
            _added = new LinkedList<T>();
            _udated = new LinkedList<T>();
            _deleted = new LinkedList<T>();
       }

        public void Commit()
        {
            _persistent.Add(_added);
            _persistent.Update(_udated);
            _persistent.Delete(_deleted);
        }

        public void TrackCollection(IEnumerable<T> entities)
        {
            foreach (var e in entities)
                TackWithoutDelete(e);

            HandleDelete(entities);
        }

        private void HandleDelete(IEnumerable<T> entities)
        {
            var map2 = entities.ToDictionary(e => e.Id);
            foreach(var o in _base)
                if (!map2.ContainsKey(o.Key))
                    Delete(o.Value);
        }
        private void TackWithoutDelete(T entity)
        {
            if (!_base.ContainsKey(entity.Id))
                Add(entity);
            else
            {
                var ob = _base[entity.Id];
                if (!ob.Equals(entity))
                    Update(entity);          
            }
        }
        private void Add(T entity)
        {
            _added.AddLast(entity);
        }
        private void Update(T entity)
        {
            _udated.AddLast(entity);
        }
        private void Delete(T entity)
        {
            _deleted.AddLast(entity);
        }
    }
}
