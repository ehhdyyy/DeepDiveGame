using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public static UpgradeShop Instance;

    [Header("References")]
    public CoinManager coinManager;
    public PlayerStats playerStats;
    public OxygenSystem oxygenSystem;

    [Header("UI Text")]
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI magnetText;

    [Header("Buttons")]
    public Button speedButton;
    public Button oxygenButton;
    public Button magnetButton;

    [Header("Speed Upgrade")]
    public int speedLevel = 0;
    public int speedMaxLevel = 5;
    public int speedCost = 1;
    public int speedCostIncrease = 2;
    public float speedUpgradeAmount = 1f;

    [Header("Oxygen Upgrade")]
    public int oxygenLevel = 0;
    public int oxygenMaxLevel = 5;
    public int oxygenCost = 1;
    public int oxygenCostIncrease = 2;
    public float oxygenUpgradeAmount = 20f;

    [Header("Magnet Upgrade")]
    public int magnetLevel = 0;
    public int magnetMaxLevel = 5;
    public int magnetCost = 1;
    public int magnetCostIncrease = 2;
    public float magnetUpgradeAmount = 5f;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        RefreshUI();
    }

    public void BuySpeedUpgrade()
    {
        if (speedLevel >= speedMaxLevel)
            return;

        if (coinManager.SpendCoins(speedCost))
        {
            speedLevel++;
            playerStats.moveSpeed += speedUpgradeAmount;
            speedCost += speedCostIncrease;
            RefreshUI();
            Debug.Log("Speed upgrade purchased!");
        }
    }

    public bool IsMaxedOut()
    {
        return speedLevel >= speedMaxLevel && oxygenLevel >= oxygenMaxLevel && magnetLevel >= magnetMaxLevel;
    }

    public void BuyOxygenUpgrade()
    {
        if (oxygenLevel >= oxygenMaxLevel)
            return;

        if (coinManager.SpendCoins(oxygenCost))
        {
            oxygenLevel++;
            playerStats.maxOxygen += oxygenUpgradeAmount;
            oxygenSystem.currentOxygen = playerStats.maxOxygen;
            oxygenCost += oxygenCostIncrease;
            RefreshUI();
            Debug.Log("Oxygen upgrade purchased!");
        }
    }

    public void BuyMagnetUpgrade()
    {
        if (magnetLevel >= magnetMaxLevel)
            return;

        if (coinManager.SpendCoins(magnetCost))
        {
            magnetLevel++;
            playerStats.magnetRange += magnetUpgradeAmount;
            magnetCost += magnetCostIncrease;
            RefreshUI();
            Debug.Log("Magnet upgrade purchased!");
        }
    }

    void RefreshUI()
    {
        if (speedLevel >= speedMaxLevel)
        {
            speedText.text = "Speed\nLv. MAX";
            speedButton.interactable = false;
        }
        else
        {
            speedText.text = "Speed\nLv. " + speedLevel + "/" + speedMaxLevel + "\nCost: " + speedCost;
            speedButton.interactable = true;
        }

        if (oxygenLevel >= oxygenMaxLevel)
        {
            oxygenText.text = "Oxygen\nLv. MAX";
            oxygenButton.interactable = false;
        }
        else
        {
            oxygenText.text = "Oxygen\nLv. " + oxygenLevel + "/" + oxygenMaxLevel + "\nCost: " + oxygenCost;
            oxygenButton.interactable = true;
        }

        if (magnetLevel >= magnetMaxLevel)
        {
            magnetText.text = "Magnet\nLv. MAX";
            magnetButton.interactable = false;
        }
        else
        {
            magnetText.text = "Magnet\nLv. " + magnetLevel + "/" + magnetMaxLevel + "\nCost: " + magnetCost;
            magnetButton.interactable = true;
        }
    }
}