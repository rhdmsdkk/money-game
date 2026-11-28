using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    [SerializeField] private GameObject _peoplePrefab;
    [SerializeField] private SortManager _sortManager;

    private People _activePeople;
    private int _numPeople = 0;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    private void Start()
    {
        //SpawnPeople("Jayden");
        //SpawnPeople("Rachel");
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

    private void SpawnPeople(string name)
    {
        _numPeople += 1;

        Vector3 peoplePosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (_numPeople - 1)), 0f);
        People people = Instantiate(_peoplePrefab, transform.position + peoplePosition, Quaternion.identity, transform).GetComponent<People>();
        people.Init(name);
    }
}
