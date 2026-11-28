using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class People : MonoBehaviour, IPointerClickHandler
{
    private string _name;

    private TextMeshProUGUI _text;
    private PeopleManager _peopleManager;

    private readonly Color BLUE = new(0f, 84f / 255f, 1f, 1f);
    private readonly Color PURPLE = new(125f / 255f, 0f, 1f, 1f);

    private void Awake()
    {
        _peopleManager = FindAnyObjectByType<PeopleManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(string name)
    {
        _name = name;

        _text.text = _name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _peopleManager.SetActivePeople(this);
    }

    public void Select()
    {
        _text.color = PURPLE;
    }

    public void UnSelect()
    {
        _text.color = BLUE;
    }
}
