using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlueText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI _text;

    private const FontStyles DEFAULT_FONT_STYLE = FontStyles.Bold;
    private const FontStyles ACTIVE_FONT_STYLE = FontStyles.Bold | FontStyles.Underline;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.fontStyle = ACTIVE_FONT_STYLE;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.fontStyle = DEFAULT_FONT_STYLE;
    }
}
