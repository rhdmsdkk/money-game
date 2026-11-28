using UnityEngine;

public class SpendManager : MonoBehaviour
{
    [SerializeField] private GameObject _spendOptionPrefab;

    private int _numOptions = 0;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    public void SpawnSpendOption(Mapping mapping)
    {
        _numOptions += 1;

        Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numOptions - 1)), 0f);
        SpendOption spendOption = Instantiate(_spendOptionPrefab, transform.position + spendOptionPosition, Quaternion.identity, transform).GetComponent<SpendOption>();

        spendOption.Init(mapping);
    }
}
