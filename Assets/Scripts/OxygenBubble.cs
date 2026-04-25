using UnityEngine;

// OxygenBubble handles the player's collision with oxygen bubbles. When collision is detected, it refills the player's oxygen and plays a sound effect.
public class OxygenBubble : MonoBehaviour
{
    public float oxygenAmount = 25f;
    public bool destroyOnPickup = true;
    private AudioSource bubblePop;

    void Start()
    {
        bubblePop = GetComponent<AudioSource>();
    }

    // Handle player collision with oxygen bubble, refill oxygen and play sound effect
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OxygenSystem oxygenSystem = other.GetComponent<OxygenSystem>();
            Debug.Log("player hit");

            if (oxygenSystem != null)
            {
                oxygenSystem.RefillOxygen(oxygenAmount);
                AudioSource.PlayClipAtPoint(bubblePop.clip, transform.position);

                if (destroyOnPickup)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}