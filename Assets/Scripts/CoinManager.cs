using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int coins = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        UpdateUI();
    }

    public void AddCoin(int amt)
    {
        coins += amt;
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins < amount)
            return false;

        coins -= amount;
        UpdateUI();
        return true;
    }

    public int GetCoins()
    {
        return coins;
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}