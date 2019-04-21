using System.Collections.Generic;

public class Chat
{
    public string Name;
    public List<ChatMessage> Messages;

    public Chat(string name)
    {
        Name = name;
    }
}