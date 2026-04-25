using TMPro;
using UnityEngine;
using UnityEngine.UI;

// OxygenSystem manages the player's oxygen levels, including draining oxygen over time, refilling in safe zones, and handling death when oxygen runs out. It also updates the UI display of oxygen levels.
public class OxygenSystem : MonoBehaviour
{
    private PlayerStats stats;

    public float currentOxygen;
    public float drainRate = 1f; // per second
    public TextMeshProUGUI oxygenLabel;
    public Slider oxygenSlider;
    public bool isInSafeZone = false;
    public float refillRate = 5f;

    [Header("Death Screen")]
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private TextMeshProUGUI deathMessage;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        currentOxygen = stats.maxOxygen;
        UpdateUI();
    }

    // Update is called once per frame. Handles oxygen drain and refill logic based on whether player is in a safe zone.
    void Update()
    {
        if (isInSafeZone)
        {
            RefillOxygen(refillRate * Time.deltaTime);
        }
        else
        {
            DrainOxygen();
        }
    }

    // Handles oxygen drain over time, updates UI, and triggers death sequence if oxygen runs out
    void DrainOxygen()
    {
        currentOxygen -= drainRate * Time.deltaTime;
        oxygenLabel.text = "Oxygen: " + currentOxygen.ToString("F0") + "/" + stats.maxOxygen.ToString("F0");
        oxygenSlider.value = currentOxygen;
        oxygenSlider.maxValue = stats.maxOxygen;

        if (currentOxygen < 0)
            currentOxygen = 0;

        UpdateUI();

        if (currentOxygen == 0)
        {
            deathScreenUI.SetActive(true);
            deathMessage.text = "You ran out of oxygen!";
            Time.timeScale = 0f;
        }
    }

    // Call this to refill oxygen when player collects oxygen bubbles or is in a safe zone
    public void RefillOxygen(float amount)
    {
        currentOxygen += amount;

        if (currentOxygen > stats.maxOxygen)
            currentOxygen = stats.maxOxygen;

        UpdateUI();
    }

    void UpdateUI()
    {
        oxygenLabel.text = "Oxygen: " + currentOxygen.ToString("F0") + "/" + stats.maxOxygen.ToString("F0");
        oxygenSlider.maxValue = stats.maxOxygen;
        oxygenSlider.value = currentOxygen;
    }
}