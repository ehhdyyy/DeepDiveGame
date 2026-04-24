using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    public float oxygenAmount = 25f;
    public bool destroyOnPickup = true;
    private AudioSource bubblePop;

    void Start()
    {
        bubblePop = GetComponent<AudioSource>();
    }

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