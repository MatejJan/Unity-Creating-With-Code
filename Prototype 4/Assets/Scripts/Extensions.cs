using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static T Random<T>(this IEnumerable<T> items)
    {
        T[] itemsArray = items.ToArray();
        return itemsArray[UnityEngine.Random.Range(0, itemsArray.Length)];
    }
}
