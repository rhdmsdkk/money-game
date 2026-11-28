using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpendManager _spendManager;

    private void Start()
    {
        _spendManager = FindAnyObjectByType<SpendManager>();

        _spendManager.SpawnSpendOption(INIT);
    }

    float t = 0f;
    private void Update()
    {
        t += Time.deltaTime;

        if (t >= 5f)
        {
            Debug.Log("process event");
            t = 0f;
        }
    }

    private const string ENGINEER = "Engineer";
    private const string ACCOUNTANT = "Accountant";
    private const string MANUAL_LABORER = "Manual laborer";

    private static readonly List<string> DEFAULT_CATEGORIES = new List<string>
    {
        ENGINEER,
        ACCOUNTANT,
        MANUAL_LABORER
    };

    private readonly Mapping INIT = new("Eat food", 10, "Jayden", DEFAULT_CATEGORIES);
}

public class Mapping
{
    public string activity;
    public int cost;

    public string name;

    public List<string> categories;

    public Mapping(string activity, int cost)
    {
        this.activity = activity;
        this.cost = cost;
    }

    public Mapping(string activity, int cost, string name, List<string> categories)
    {
        this.activity = activity;
        this.cost = cost;
        this.name = name;
        this.categories = categories;
    }
}
