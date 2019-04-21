using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentorShopTipTrigger : MonoBehaviour
{
    public static Button Shop;

    public static void ShowShopTip()
    {
        MentorUI.Message(Texts.MapMentorPhrase, Shop);
    }
}