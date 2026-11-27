using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int _money;
    
    private TextMeshProUGUI _moneyText;

    private void Start()
    {
        _moneyText = GetComponentInChildren<TextMeshProUGUI>();

        SetMoneyText();
    }

    public void SpendMoney(int spentMoney)
    {
        int res = _money - spentMoney;

        if (res < 0)
        {
            return;
        }

        _money = res;
        SetMoneyText();
    }

    private void SetMoneyText()
    {
        _moneyText.text = "$" + _money;
    }
}
