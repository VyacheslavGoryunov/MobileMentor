using System;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static string WelcomeMessage => Instance.GetContent("WelcomeMessage");
    public static string MentorName => Instance.GetContent("MentorName");
    
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

        return result;
    }
}