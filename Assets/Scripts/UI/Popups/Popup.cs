using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Popup<T> : MonoBehaviour
{
    protected const string PopupUiPath = "Prefabs/Popups/PopupUI";
    
    public Action<T> Result;

    public virtual void Submit(T result)
    {
        Result?.Invoke(result);
        
        Destroy(transform.parent.gameObject);
    }
}
