using System.Runtime.InteropServices.ComTypes;

namespace FunctionalProgrammingCSharp;

public static class ExtensionMethods
{
    // public static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
    // {
    //     // foreach (T t in ts)
    //     // {
    //     //     if (predicate(t))
    //     //     {
    //     //         yield return t;
    //     //     }
    //     // }
    //     return Enumerable.Where(ts, t => predicate(t));
    //     return Enumerable.Where(ts, predicate);
    // }

    public static Func<T2, T1, R> SwapArgs<T1, T2, R>(this Func<T1, T2, R> f) => (t2, t1) => f(t1, t2);
}

class Cache<T> where T : class, new()
{
    private T Get(Guid id)
    {       
        return new T();
    }

    public T Get(Guid id, Func<T> onMiss) => Get(id) ?? onMiss();
}