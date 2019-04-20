using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    private Graphic _currentHighlighted;

    void Awake()
    {
        _instance = this;
    }
    
    public void ShowMessage(string message, Graphic highlightedElement = null, UnityAction callback = null,
        TextAnchor alignment = TextAnchor.UpperLeft)
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

    public void Highlight(Graphic target)
    {
        _highlightedParent = target.transform;
        target.transform.SetParent(Overlay);
    }

    public static void Message(string message, Graphic highlightedElement = null, UnityAction callback = null,
        TextAnchor alignment = TextAnchor.UpperLeft)
    {
        Instance.ShowMessage(message, highlightedElement, callback, alignment);
    }
}
