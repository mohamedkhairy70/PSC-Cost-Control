using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC_Cost_Control.Helper
{
    public static class Helper
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> col, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach (var item in col)
            {
                action(item);
            }
            return col;
        }
    }
}
