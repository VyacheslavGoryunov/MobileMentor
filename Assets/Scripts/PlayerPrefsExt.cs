using System;
using UnityEngine;

public static class PlayerPrefsExt
{
    public static void SetBool(string key, bool val)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(val));
    }

    public static bool GetBool(string key, bool def = false)
    {
        return !PlayerPrefs.HasKey(key) ? def : Convert.ToBoolean(PlayerPrefs.GetInt(key));
    }
}