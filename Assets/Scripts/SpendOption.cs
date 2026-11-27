using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private MoneyManager _moneyManager;

    public string _activity;
    public int _cost;

    private TextMeshProUGUI _text;

    private const FontStyles DEFAULT_FONT_STYLE = FontStyles.Bold;
    private const FontStyles ACTIVE_FONT_STYLE = FontStyles.Bold | FontStyles.Underline;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.fontStyle = ACTIVE_FONT_STYLE;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.fontStyle = DEFAULT_FONT_STYLE;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _moneyManager.SpendMoney(_cost);
    }
}
