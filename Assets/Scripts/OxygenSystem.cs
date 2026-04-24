using TMPro;
using UnityEngine;
using UnityEngine.UI;

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