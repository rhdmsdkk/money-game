using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class People : MonoBehaviour, IPointerClickHandler
{
    protected TextMeshProUGUI _text;
    private PeopleManager _peopleManager;

    private void Awake()
    {
        _peopleManager = FindAnyObjectByType<PeopleManager>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // open sorting window
    }
}
