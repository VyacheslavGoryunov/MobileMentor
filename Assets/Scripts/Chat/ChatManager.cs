using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    private const string path = "chats.json";
    
    public List<Message> Chats;
    public RectTransform ChatBox;
    public Message MessagePrefab;
    
    private float _rowHeight;
    private List<Chat> _chats;

    private void Awake()
    {
        _rowHeight = MessagePrefab.GetComponent<RectTransform>().sizeDelta.y;
    }

    private void Start()
    {
        Load();
        
        AddChat("Макс Дорофеев", "Привет, это пробное сообщение!");
        AddChat("Вася Пупкин", "Привет, это второе пробное сообщение!");
    }

    public void Save()
    {
        if (_chats == null)
        {
            _chats = new List<Chat>();
        }
        File.WriteAllText(path, JsonUtility.ToJson(_chats));
    }
    
    public void Load()
    {
        try
        {
            var json = File.ReadAllText(path);
        }
        catch (Exception)
        {
            _chats = new List<Chat>();
        }
    }

    public void PushMessage(string sender, string message)
    {
        var targetChat = _chats.FirstOrDefault(c => c.Name == sender);

        if (targetChat == null)
        {
            AddChat(sender, message.Substring(0, 20));
            targetChat = new Chat(sender);
            _chats.Add(targetChat);
        }
        
        targetChat.Messages.Add(new ChatMessage());
    }
    
    public void AddChat(string senderName, string content)
    {
        var newMessage = Instantiate(MessagePrefab, ChatBox.transform);
        newMessage.Name.text = senderName;
        newMessage.Content.text = content;
        Chats.Add(newMessage);
        MeasureChats();
    }

    public void MeasureChats()
    {
        var height = _rowHeight * Chats.Count;
        var size = ChatBox.sizeDelta;
        ChatBox.sizeDelta = new Vector2(size.x, height);
    }
}