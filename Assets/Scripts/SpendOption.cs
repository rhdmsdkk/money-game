using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendOption : MonoBehaviour, IPointerClickHandler
{
    private string _activity;
    private int _cost;
    private string _peopleName; // optional

    protected TextMeshProUGUI _text;
    private MoneyManager _moneyManager;
    private PeopleManager _peopleManager;

    private void Awake()
    {
        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _peopleManager = FindAnyObjectByType<PeopleManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string activity, int cost)
    {
        _activity = activity;
        _cost = cost;

        _text.text = _activity + " | $" + _cost;
    }

    public void Init(string activity, int cost, string name)
    {
        _activity = activity;
        _cost = cost;
        _peopleName = name;

        _text.text = _activity + " | $" + _cost;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_moneyManager.SpendMoney(_cost))
        {
            Destroy(gameObject);
            _peopleManager.SpawnPeople(_peopleName);
        }
    }
}
