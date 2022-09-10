using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [ShowNonSerializedField] private int _money;

    private TMP_Text _moneyText;

    private void Start()
    {
        _moneyText = GetComponent<TMP_Text>();
        _money = PlayerPrefs.GetInt("Money", 0);
        SetMoney();
    }

    public void SetMoney(int value = 0)
    {
        _money += value;
        PlayerPrefs.SetInt("Money", _money);
        print(value);
        _moneyText.text = $"{_money} $";
    }
}
