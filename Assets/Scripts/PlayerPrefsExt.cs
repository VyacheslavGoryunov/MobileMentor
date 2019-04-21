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
    
    public static void SetObject<T>(string key, T obj)
    {
        PlayerPrefs.SetString(key, JsonUtility.ToJson(obj, false));
    }

    public static T GetObject<T>(string key, T def = default)
    {
        return !PlayerPrefs.HasKey(key) ? def : JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
    }

    public static void SetUser(User user)
    {
        SetObject(Consts.UserKey, user);
        User.Current = user;
    }

    public static User GetUser()
    {
        return GetObject<User>(Consts.UserKey);
    }
}