using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private GameObject _peoplePrefab;
    [SerializeField] private SortManager _sortManager;

    private People _activePeople;
    private int _numPeople = 0;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    private void Update()
    {
        if (transform.childCount != _numPeople)
        {
            Reposition();
        }
    }

    public void SetActivePeople(People people)
    {
        if (_activePeople != null)
        {
            _activePeople.UnSelect();
        }

        people.Select();
        _activePeople = people;

        _sortManager.gameObject.SetActive(true);
    }

    public void ClearActivePeople()
    {
        _activePeople = null;

        _sortManager.gameObject.SetActive(false);
    }

    public void SpawnPeople(Mapping mapping)
    {
        _numPeople += 1;

        Vector3 peoplePosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numPeople - 1)), 0f);
        People people = Instantiate(_peoplePrefab, transform.position + peoplePosition, Quaternion.identity, transform).GetComponent<People>();
        people.Init(mapping);
    }

    private void Reposition()
    {
        _numPeople -= 1;

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
