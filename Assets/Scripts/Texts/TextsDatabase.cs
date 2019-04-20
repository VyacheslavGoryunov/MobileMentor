using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TextDatabase", menuName = "Texts/Database", order = 1)]
public class TextsDatabase : ScriptableObject
{
    public TextEntry[] Entries;

    public string this[string index] => Entries.Where(e => e.Key == index).Select(e => e.Content).FirstOrDefault();

    [Serializable]
    public struct TextEntry
    {
        public string Key;
        [Multiline]
        public string Content;
    }
}
