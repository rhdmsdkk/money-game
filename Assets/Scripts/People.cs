using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class People : MonoBehaviour, IPointerClickHandler
{
    private Mapping _mapping;

    private TextMeshProUGUI _text;
    private PeopleManager _peopleManager;
    private SortManager _sortManager;

    private readonly Color BLUE = new(0f, 84f / 255f, 1f, 1f);
    private readonly Color PURPLE = new(125f / 255f, 0f, 1f, 1f);

    private void Awake()
    {
        _peopleManager = FindAnyObjectByType<PeopleManager>();
        _sortManager = FindAnyObjectByType<SortManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Init(Mapping mapping)
    {
        _mapping = mapping;
        _text.text = mapping.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _peopleManager.SetActivePeople(this);
        _sortManager.Init(_mapping);
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
