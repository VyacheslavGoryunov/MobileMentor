using System;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static string WelcomeMessage => Instance.GetContent("WelcomeMessage");
    public static string MentorName => Instance.GetContent("MentorName");
    public static string GreetingComplete => Instance.GetContent("GreetingComplete");
    public static string RoomGreeting => Instance.GetContent("RoomGreeting");
    public static string MapTip => Instance.GetContent("MapTip");
    public static string PhoneBuy => Instance.GetContent("PhoneBuy");
    
    public static Texts Instance => _instance;
    private static Texts _instance;
    
    public TextsDatabase Database;

    void Awake()
    {
        _instance = this;
    }
    
    public string GetContent(string key)
    {
        var result = Database[key];
        var keys = new string[] { "MentorName" };
        
        foreach (var s in keys)
        {
            if (s == key) continue;
            
            //TODO: refactor it
            result = result?.Replace("{" + s + "}", GetContent(s));
        }
        
        //todo: and it...
        if (User.Current != null)
        {
            result = result?.Replace("{Username}", User.Current.Name);
        }

        return result;
    }
}