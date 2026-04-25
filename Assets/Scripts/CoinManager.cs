using UnityEngine;
using TMPro;

// CoinManager handles the player's coin count, including adding coins when collected and spending coins on upgrades. It also updates the UI display of coins.
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

    // Call this to add coins when player collects them
    public void AddCoin(int amt)
    {
        coins += amt;
        UpdateUI();
    }

    // Call this to spend coins when player buys upgrades
    public bool SpendCoins(int amount)
    {
        if (coins < amount)
            return false;

        coins -= amount;
        UpdateUI();
        return true;
    }

    // Returns current coin counts for UI displays and other checks
    public int GetCoins()
    {
        return coins;
    }

    // Updates coin count display in the UI
    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}