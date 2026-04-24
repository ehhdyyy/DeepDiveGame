using UnityEngine;
using TMPro;

public class FishManager : MonoBehaviour
{
    public static FishManager Instance;

    [SerializeField] private TextMeshProUGUI FishText;
    [SerializeField] private int FishCount = 0;

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

    public void AddFish(int amt)
    {
        FishCount += amt;
        UpdateUI();
    }


    public int GetFish()
    {
        return FishCount;
    }

    private void UpdateUI()
    {
        if (FishText != null)
        {
            FishText.text = "Fish: " + FishCount;
        }
    }
}