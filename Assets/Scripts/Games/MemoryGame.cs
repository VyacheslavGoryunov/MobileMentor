using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;
using Random = System.Random;

public class MemoryGame : MonoBehaviour
{
    public GameObject ButtonParent;
    public Button[] Buttons;

    private Dictionary<int, Button> _buttonsDictionary = new Dictionary<int, Button>();
    private int _currentLevel;

    private void Start()
    {
        _currentLevel = 0;

        for (int i = 0; i < Buttons.Length; i++)
        {
            var button = Buttons[i];
            _buttonsDictionary.Add(i, button);
        }

        CreateRandomizeChallenge();
    }

    private void CreateRandomizeChallenge()
    {
        var numbers = new int[0];
        var random = new Random();
        switch (_currentLevel)
        {
            case 0:
                numbers = new int[4];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(9);
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    var buttonGameObject = _buttonsDictionary[numbers[i]].gameObject;
                    var tweenColor = buttonGameObject.AddComponent<uTweenColor>();
                    tweenColor.@to = Color.yellow;
                    tweenColor.loopStyle = LoopStyle.Once;
                    tweenColor.onFinished = new UnityEvent();
                    tweenColor.onFinished.AddListener(() => { });
                }

                break;
            case 1:
                numbers = new int[5];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(9);
                }

                break;
            case 2:
                numbers = new int[6];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(9);
                }

                break;
        }
    }

    private bool CheckResult(string result)
    {
        return false;
    }
}