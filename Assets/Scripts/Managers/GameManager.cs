using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SpendManager _spendManager;
    private MoneyManager _moneyManager;

    private int _milestone = 0;

    private void Start()
    {
        _spendManager = FindAnyObjectByType<SpendManager>();
        _moneyManager = FindAnyObjectByType<MoneyManager>();

        _spendManager.SpawnSpendOption(INIT);
        _spendManager.SpawnSpendOption(INIT); // TODO: delete
        _spendManager.SpawnSpendOption(INIT); // TODO: delete
        _spendManager.SpawnSpendOption(INIT); // TODO: delete
        _spendManager.SpawnSpendOption(INIT); // TODO: delete
    }

    #region Events
    float t = 0f;
    private void Update()
    {
        t += Time.deltaTime;

        if (t >= 5f)
        {
            CheckMoney();
            t = 0f;
        }
    }

    // check for money milestones
    private void CheckMoney()
    {
        int money = _moneyManager.GetMoney();

        switch(_milestone)
        {
            case 0:
                if (money >= 40)
                {
                    MilestoneOne();
                }
                break;
            case 1:
                if (money >= 150)
                {
                    MilestoneTwo();
                }
                break;
        }
    }

    private void MilestoneOne()
    {
        Debug.Log("EVENT: milestone 1");
        _milestone += 1;
    }

    private void MilestoneTwo()
    {
        Debug.Log("EVENT: milestone 2");
        _milestone += 1;
    }
    #endregion

    private const string ENGINEER = "Engineer";
    private const string ACCOUNTANT = "Accountant";
    private const string MANUAL_LABORER = "Manual laborer";

    private static readonly List<string> DEFAULT_CATEGORIES = new()
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
