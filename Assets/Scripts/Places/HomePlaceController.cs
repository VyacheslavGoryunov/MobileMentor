using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePlaceController : MonoBehaviour
{
    private const string FirstTimeKey = "first_time";

    void Start()
    {
        if (PlayerPrefsExt.GetBool(FirstTimeKey, true))
        {
            MentorUI.Message(Texts.WelcomeMessage);

            if (!Application.isEditor)
            {
                PlayerPrefsExt.SetBool(FirstTimeKey, false);
            }
        }
    }
}
