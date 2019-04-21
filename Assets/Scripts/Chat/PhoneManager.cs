using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public Button PhoneButton;
    public int CurrentPhone;

    private static PhoneManager _phoneManager;

    public static PhoneManager Instance
    {
        get => _phoneManager;
    }

    private void Awake()
    {
        _phoneManager = this;
    }

    private void Start()
    {
        SetPhone(-1);
    }

    public void SetPhone(int id)
    {
        CurrentPhone = id;
        PhoneButton.gameObject.SetActive(id > -1);
    }
}
