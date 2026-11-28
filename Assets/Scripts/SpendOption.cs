using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendOption : MonoBehaviour, IPointerClickHandler
{
    private string _activity;
    private int _cost;

    protected TextMeshProUGUI _text;
    private MoneyManager _moneyManager;

    private void Awake()
    {
        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string activity, int cost)
    {
        _activity = activity;
        _cost = cost;

        _text.text = _activity + " | $" + _cost;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _moneyManager.SpendMoney(_cost);

        Destroy(gameObject);
    }
}
