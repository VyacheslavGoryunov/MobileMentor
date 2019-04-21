using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GreetingPopup : Popup<GreetingPopupData>
{
    private const string PrefabPath = "Prefabs/Popups/GreetingPopup";
    
    public Toggle[] SexToggles;
    public InputField NameInput;
    public Button SubmitButton;

    public static GreetingPopup Create(Action<GreetingPopupData> callback)
    {
        var parent = Instantiate(Resources.Load<Transform>(PopupUiPath));
        var popup = Instantiate(Resources.Load<GreetingPopup>(PrefabPath), parent);

        popup.Result = callback;
        
        return popup;
    }
    
    void Start()
    {
        SubmitButton.onClick.AddListener(OnSubmit);
    }

    public void OnSubmit()
    {
        var activeSex = SexToggles.Select((t, i) => new {t, i}).First(pair => pair.t.isOn).i;
        
        Submit(new GreetingPopupData(NameInput.text, activeSex == 0));
    }
}
