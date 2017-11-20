using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public static class IEnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var value in self)
                action(value);
        }
    }
}
