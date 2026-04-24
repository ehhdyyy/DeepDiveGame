using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float baseSpeed = 5f;
    public float baseOxygen = 100f;
    public float baseMagnetRange = 5f;

    [Header("Current Stats")]
    public float moveSpeed;
    public float maxOxygen;
    public float magnetRange;

    void Start()
    {
        moveSpeed = baseSpeed;
        maxOxygen = baseOxygen;
        magnetRange = baseMagnetRange;
    }
}