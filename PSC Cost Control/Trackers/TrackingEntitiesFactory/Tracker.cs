﻿using PSC_Cost_Control.Helper.Interfaces;
using PSC_Cost_Control.Trackers.PersistantCruds;
using System.Collections.Generic;
using System.Linq;

namespace PSC_Cost_Control.Trackers
{
   
    public class Tracker<T> : ITracker<T> where T : IHasId
    {
        private IDictionary<int, T> _base;
        private LinkedList<T> _added;
        private LinkedList<T> _deleted;
        private LinkedList<T> _udated;
        private IPersistent<T> _persistent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persistent">Repository that handle Commiting data </param>
        /// <param name="origin">the existed data.if tracking is for database handling,then origin is the database existed data.</param>
        public Tracker(IPersistent<T> persistent, IEnumerable<T> origin)
        {
            _persistent = persistent;
            _base = origin.ToDictionary(o => o.Id);
            _added = new LinkedList<T>();
            _udated = new LinkedList<T>();
            _deleted = new LinkedList<T>();
        }

        public void Commit()
        {
            _persistent.DeleteCollection(_deleted);
            _persistent.AddCollection(_added);
            _persistent.UpdateCollction(_udated);
        }

        public void TrackCollection(IEnumerable<T> entities)
        {
            foreach (var e in entities)
                TackWithoutDelete(e);

            HandleDelete(entities);
        }

        private void HandleDelete(IEnumerable<T> entities)
        {
            var map2 = entities.Where(e=>e.Id!=0).ToDictionary(e => e.Id);

            foreach (var o in _base)
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

        public IEnumerable<T> GetNewEntities() => _added;

        public IEnumerable<T> GetUpdatedEntities() => _udated;
        public IEnumerable<T> GetDeletedEntities() => _deleted;
         
    }
}
