using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseUpRepeater : MonoBehaviour
{
    public UnityEvent MouseUpEvent;

    private void OnMouseUp()
    {
        MouseUpEvent?.Invoke();
    }
}
