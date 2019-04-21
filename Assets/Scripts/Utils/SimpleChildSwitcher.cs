using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleChildSwitcher : MonoBehaviour
{
    public GameObject[] Children;

    public void Switch(GameObject target)
    {
        foreach (var child in Children)
        {
            child.SetActive(child.Equals(target));
        }
    }
}
