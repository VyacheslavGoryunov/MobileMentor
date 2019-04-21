using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneShop : MonoBehaviour
{
    public PhoneDatabase Database;
    public Image Preview;
    public Text PriceLabel;
    public Button LeftButton;
    public Button RightButton;
    public Button BuyButton;
    public string PriceFormat = "{0} points";

    public int Current
    {
        get => _current;
        set
        {
            _current = value;

            if (_current >= Database.Phones.Length)
            {
                _current = 0;
            }
            else if (_current < 0)
            {
                _current = Database.Phones.Length - 1;
            }

            RefreshUi();
        }
    }

    private int _current;

    void Awake()
    {
        BindAll();
        Current = 0;
    }

    protected void BindAll()
    {
        LeftButton.onClick.AddListener(Next);
        RightButton.onClick.AddListener(Back);
        BuyButton.onClick.AddListener(Buy);
    }

    public void Next()
    {
        Current++;
    }

    public void Back()
    {
        Current--;
    }

    public void Buy()
    {
        PhoneManager.Instance.SetPhone(Current);
        MentorUI.Message(Texts.PhoneBuy, PhoneManager.Instance.PhoneButton, null, TextAnchor.MiddleLeft, true);
        PhoneManager.Instance.PhoneButton.onClick.AddListener(OnPhoneClicked);
    }

    private void OnPhoneClicked()
    {
        MentorUI.HideAll();
        PhoneManager.Instance.PhoneButton.onClick.RemoveListener(OnPhoneClicked);
    }

    protected void RefreshUi()
    {
        if (_current > Database.Phones.Length)
            return;

        var phone = Database.Phones[_current];

        Preview.sprite = phone.Picture;
        PriceLabel.text = string.Format(PriceFormat, phone.Price);
    }
}