using System.Collections.Generic;

public static class ApiUtils
{
    public static void AddNonNullToList<T>(List<T> list, params T[] items)
    {
        foreach (var item in items)
        {
            if (item != null)
                list.Add(item);
        }
    }
}
