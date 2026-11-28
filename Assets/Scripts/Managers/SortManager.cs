using UnityEngine;

public class SortManager : MonoBehaviour
{
    [SerializeField] private GameObject _categoryPrefab;

    private const float SPAWN_DEFAULT_VALUE = 2f;
    private const float SPAWN_DISTANCE_MULTIPLIER = 40f;

    public void Init(Mapping mapping)
    {
        int i = 0;
        foreach (string categoryName in mapping.categories)
        {
            i += 1;

            Vector3 categoryPosition = new(0f, SPAWN_DEFAULT_VALUE - (SPAWN_DISTANCE_MULTIPLIER * (i - 1)), 0f);
            Category category = Instantiate(_categoryPrefab, transform.position + categoryPosition, Quaternion.identity, transform).GetComponent<Category>();

            category.Init(categoryName);
        }
    }
}
