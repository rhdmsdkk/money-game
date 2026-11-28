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

    public bool SpendMoney(int spentMoney)
    {
        int res = _money - spentMoney;

        if (res < 0)
        {
            return false;
        }

        _money = res;
        SetMoneyText();
        return true;
    }

    private void SetMoneyText()
    {
        _moneyText.text = "$" + _money;
    }

    public int GetMoney()
    {
        return _money;
    }
}
