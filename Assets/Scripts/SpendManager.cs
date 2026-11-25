using UnityEngine;

public class SpendManager : MonoBehaviour
{
    [SerializeField] private GameObject _spendOptionPrefab;

    private int _numOptions = 1;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 20f;
    private string INIT_SPEND_OPTION_ACTIVITY = "Eat food";
    private int INIT_SPEND_OPTION_COST = 10;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SpawnSpendOption(INIT_SPEND_OPTION_ACTIVITY, INIT_SPEND_OPTION_COST);
    }

    private void SpawnSpendOption(string activity, int cost)
    {
        Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE + (SPAWN_DISTANCE_MULTIPLIER * _numOptions), 0f);
        SpendOption spendOption = Instantiate(_spendOptionPrefab, transform.position + spendOptionPosition, Quaternion.identity, this.transform).GetComponent<SpendOption>();
        spendOption.Init(activity, cost);
    }
}
