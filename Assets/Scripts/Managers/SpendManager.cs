using UnityEngine;

public class SpendManager : MonoBehaviour
{
    [SerializeField] private GameObject _spendOptionPrefab;

    private int _numOptions = 0;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    private void Update()
    {
        if (transform.childCount != _numOptions)
        {
            Reposition();
        }
    }

    public void SpawnSpendOption(Mapping mapping)
    {
        _numOptions += 1;

        Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numOptions - 1)), 0f);
        Debug.Log(spendOptionPosition + " " + transform.position + spendOptionPosition);
        SpendOption spendOption = Instantiate(_spendOptionPrefab, transform.position + spendOptionPosition, Quaternion.identity, transform).GetComponent<SpendOption>();

        spendOption.Init(mapping);
    }

    public void Reposition()
    {
        _numOptions -= 1;

        int i = 0;
        foreach (Transform child in transform)
        {
            i += 1;

            Vector3 spendOptionPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (i - 1)), 0f);
            Debug.Log(spendOptionPosition + " " + transform.position + spendOptionPosition);
            child.position = transform.position + spendOptionPosition;
        }
    }
}
