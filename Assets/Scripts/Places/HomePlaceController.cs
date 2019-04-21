using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomePlaceController : MonoBehaviour
{
    private const string FirstTimeKey = "first_time";

    public Button Map;
    public int GreetRoomDelay = 2;

    public static EventHandler ShowShopTip = (sender, args) => { };

    void Start()
    {
        if (PlayerPrefsExt.GetBool(FirstTimeKey, true))
        {
            MentorUI.Message(Texts.WelcomeMessage, null, () =>
            {
                MentorUI.HideAll();
                GreetingPopup.Create(GreetingCallback);
            });

            if (!Application.isEditor)
            {
                PlayerPrefsExt.SetBool(FirstTimeKey, false);
            }
        }
    }

    private void GreetingCallback(GreetingPopupData data)
    {
        PlayerPrefsExt.SetUser(new User(data.Name, data.Sex));
        MentorUI.Message(Texts.GreetingComplete, null, () => { StartCoroutine(GreetRoom()); });
    }

    private IEnumerator GreetRoom()
    {
        MentorUI.HideAll();
        yield return new WaitForSeconds(GreetRoomDelay);
        MentorUI.Message(Texts.RoomGreeting, null, OnRoomGreeted);
    }

    private void OnRoomGreeted()
    {
        Map.onClick.AddListener(OnMapClicked);
        MentorUI.Message(Texts.MapTip, Map, null, TextAnchor.LowerLeft, true);
    }
    
    private void OnMapClicked()
    {
        MentorUI.HideAll();
        Map.onClick.RemoveListener(OnMapClicked);
        MentorShopTipTrigger.ShowShopTip();
    }
}
