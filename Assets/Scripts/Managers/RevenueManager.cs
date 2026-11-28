using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RevenueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private MoneyManager _moneyManager;
    private readonly Dictionary<string, int> _directory = new();

    private void Start()
    {
        _moneyManager = FindAnyObjectByType<MoneyManager>();
        UpdateText();
    }

    private void UpdateText()
    {
        string res = "";

        foreach (string category in _directory.Keys)
        {
            res += "> " + category + " x" + _directory[category] + "\n";
        }

        _text.text = res;
    }

    public void UpdateDirectory(string category)
    {
        if (_directory.ContainsKey(category))
        {
            _directory[category] += 1;
        }
        else
        {
            _directory.Add(category, 1);
        }

        UpdateText();
    }
}
