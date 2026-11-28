using UnityEngine;

public class SpendManager : MonoBehaviour
{
    [SerializeField] private GameObject _spendOptionPrefab;

    private int _numOptions = 0;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    private const string INIT_SPEND_OPTION_ACTIVITY = "Eat food";
    private const int INIT_SPEND_OPTION_COST = 10;
    private const string INIT_PEOPLE_NAME = "Jayden";

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SpawnSpendOption(INIT_SPEND_OPTION_ACTIVITY, INIT_SPEND_OPTION_COST, INIT_PEOPLE_NAME);
        SpawnSpendOption("Fishing", 1);
    }

    private void SpawnSpendOption(string activity, int cost)
    {
        _numOptions += 1;

        Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numOptions - 1)), 0f);
        SpendOption spendOption = Instantiate(_spendOptionPrefab, transform.position + spendOptionPosition, Quaternion.identity, transform).GetComponent<SpendOption>();
        spendOption.Init(activity, cost);
    }

    private void SpawnSpendOption(string activity, int cost, string name)
    {
        _numOptions += 1;

        Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numOptions - 1)), 0f);
        SpendOption spendOption = Instantiate(_spendOptionPrefab, transform.position + spendOptionPosition, Quaternion.identity, transform).GetComponent<SpendOption>();
        spendOption.Init(activity, cost, name);
    }
}
