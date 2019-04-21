using System;

[Serializable]
public class User
{
    public delegate void UserChanged(User user);
    public static event UserChanged OnUserChanged;
    public static User Current
    {
        get => _current;
        set
        {
            _current = value;
            OnUserChanged?.Invoke(value);
        }
    }

    public string Name;
    public bool Sex;
    private static User _current;

    static User()
    {
        Current = PlayerPrefsExt.GetUser();
    }

    public User(string name, bool sex)
    {
        Name = name;
        Sex = sex;
    }
}