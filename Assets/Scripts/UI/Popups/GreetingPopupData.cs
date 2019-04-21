using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GreetingPopupData
{
    public string Name { get; private set; }
    public bool Sex { get; private set; }
    
    public GreetingPopupData(string name, bool sex)
    {
        Name = name;
        Sex = sex;
    }
}
