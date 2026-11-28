using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Category : MonoBehaviour, IPointerClickHandler
{
    private string _category;

    private TextMeshProUGUI _text;
    private RevenueManager _revenueManager;
    private PeopleManager _peopleManager;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _revenueManager = FindAnyObjectByType<RevenueManager>();
        _peopleManager = FindAnyObjectByType<PeopleManager>();
    }

    public void Init(string category)
    {
        _category = category;
        _text.text = _category;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _peopleManager.ClearActivePeople();
        _revenueManager.UpdateDirectory(_category);
    }
}
