namespace Api.JWT.Core;

public static class CollectionExtension
{
    public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue>? dict)
    {
        return dict == null || dict.Count == 0;
    }

    public static bool IsNullOrEmpty<T>(this IList<T>? list)
    {
        return list == null || list.Count == 0;
    }
}