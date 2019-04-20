using UnityEngine;

[CreateAssetMenu(fileName = "PhoneDatabase", menuName = "Phone/Database", order = 1)]
public class PhoneDatabase : ScriptableObject
{
    public Phone[] Phones;
}