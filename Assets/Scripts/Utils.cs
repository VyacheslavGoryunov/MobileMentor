using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void RemoveAllChildren(this Transform transform)
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            Object.Destroy(transform.GetChild(0).gameObject);
        }
    }
}
