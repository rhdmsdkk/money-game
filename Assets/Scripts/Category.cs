using TMPro;
using UnityEngine;

public class Category : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string category)
    {
        _text.text = category;
    }
}
