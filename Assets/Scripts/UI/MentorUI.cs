﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MentorUI : MonoBehaviour
{
    public static MentorUI Instance => _instance;
    private static MentorUI _instance;
    
    public RectTransform UiParent;
    public Transform Overlay;
    public Text MessageLabel;
    public Button ContinueButton;

    private Transform _highlightedParent;
    private UIBehaviour _currentHighlighted;

    void Awake()
    {
        _instance = this;
    }
    
    public void ShowMessage(string message, UIBehaviour highlightedElement = null, UnityAction callback = null,
        TextAnchor alignment = TextAnchor.UpperLeft, bool hideContinue = false)
    {
        UiParent.gameObject.SetActive(true);
        //TODO: add overlaying
        //TODO: add animation
        MessageLabel.alignment = alignment;
        MessageLabel.text = message;

        if (highlightedElement)
        {
            Highlight(highlightedElement);
        }

        ContinueButton.onClick.RemoveAllListeners();
        ContinueButton.onClick.AddListener(() =>
        {
            if (callback != null)
            {
                Unhighlight();
                callback();
            }
            else
            {
                Hide();
            }
        });
        ContinueButton.gameObject.SetActive(!hideContinue);
    }

    public void Hide()
    {
        UiParent.gameObject.SetActive(false);
        Unhighlight();
    }

    public void Unhighlight()
    {
        if (_currentHighlighted)
        {
            _currentHighlighted.transform.SetParent(_highlightedParent);
            _currentHighlighted = null;
            _highlightedParent = null;
        }
    }

    public void Highlight(UIBehaviour target)
    {
        _currentHighlighted = target;
        _highlightedParent = target.transform.parent;
        target.transform.SetParent(Overlay);
    }

    public static void Message(string message, UIBehaviour highlightedElement = null, UnityAction callback = null,
        TextAnchor alignment = TextAnchor.UpperLeft, bool hideContinue = false)
    {
        Instance.ShowMessage(message, highlightedElement, callback, alignment, hideContinue);
    }

    public static void HideAll()
    {
        Instance.Hide();
    }
}
