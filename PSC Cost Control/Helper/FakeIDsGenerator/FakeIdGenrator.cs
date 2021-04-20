using PSC_Cost_Control.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Helper.FakeIDsGenerator
{
    public static class FakeIdGenrator
    {
        /// <summary>
        /// Genrate an Id for every elemrnt in the passed collection.
        /// </summary>
        /// <typeparam name="T">T type that implements IHasId</typeparam>
        /// <param name="list">Enumerable collection needed to have Ids for its elements</param>
        public static IEnumerable<T> InjectFakeIds<T>(this IEnumerable<T> list) where T : IHasId
        {
            var cnt = 1;
            foreach (var e in list)
                e.Id = cnt++;
            return list;
        }

        public static IEnumerable<T> ReSolvingHireachicalParentChild<T>(this IEnumerable<T> list) where T : IHireichy
        {
            foreach (var e in list)
                if (e.HParent != null)
                    e.ParentId = e.HParent.Id;

            return list;
        }

    }
}
