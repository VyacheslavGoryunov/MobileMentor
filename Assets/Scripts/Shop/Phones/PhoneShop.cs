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
            } else if (_current < 0)
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
    }

    public void Next()
    {
        Current ++;
    }

    public void Back()
    {
        Current--;
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
