using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendOption : MonoBehaviour, IPointerClickHandler
{
    private Mapping _mapping;

    protected TextMeshProUGUI _text;
    private MoneyManager _moneyManager;
    private PeopleManager _peopleManager;

    private void Awake()
    {
        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _peopleManager = FindAnyObjectByType<PeopleManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(Mapping mapping)
    {
        _mapping = mapping;

        _text.text = mapping.activity + " | $" + mapping.cost;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_moneyManager.SpendMoney(_mapping.cost))
        {
            if (_mapping.name != null && _mapping.name != "")
            {
                _peopleManager.SpawnPeople(_mapping);
            }

            Destroy(gameObject);
        }
    }
}
