using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendOption : MonoBehaviour, IPointerClickHandler
{
    protected TextMeshProUGUI _text;
    private MoneyManager _moneyManager;

    public string _activity;
    public int _cost;

    private void Awake()
    {
        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string activity, int cost)
    {
        _activity = activity;
        _cost = cost;

        _text.text = activity + " | $" + cost;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _moneyManager.SpendMoney(_cost);

        Destroy(gameObject);
    }
}
