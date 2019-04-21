using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public List<Message> Messages;
    public RectTransform ChatBox;
    public Message MessagePrefab;
    private float _rowHeight;

    private void Awake()
    {
        _rowHeight = MessagePrefab.GetComponent<RectTransform>().sizeDelta.y;
    }

    private void Start()
    {
        AddMessage("Макс Дорофеев", "Привет, это пробное сообщение!");
        AddMessage("Вася Пупник", "Привет, это второе пробное сообщение!");
    }

    public void AddMessage(string senderName, string content)
    {
        var newMessage = Instantiate(MessagePrefab, ChatBox.transform);
        newMessage.Name.text = senderName;
        newMessage.Content.text = content;
        Messages.Add(newMessage);
        MeasureMessages();
    }

    public void MeasureMessages()
    {
        var height = _rowHeight * Messages.Count;
        var size = ChatBox.sizeDelta;
        ChatBox.sizeDelta = new Vector2(size.x, height);
    }
}