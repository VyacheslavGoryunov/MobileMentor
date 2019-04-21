using System.Collections.Generic;

public struct ChatMessage
{
    public string Content;
    public Dictionary<int, string> Answers;

    public ChatMessage(string content, Dictionary<int, string> answers)
    {
        Content = content;
        Answers = answers;
    }
}