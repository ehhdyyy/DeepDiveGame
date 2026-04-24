using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OxygenSystem oxygen = other.GetComponent<OxygenSystem>();

        if (oxygen != null)
        {
            oxygen.isInSafeZone = true;
            Debug.Log("Player entered safe zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OxygenSystem oxygen = other.GetComponent<OxygenSystem>();

        if (oxygen != null)
        {
            oxygen.isInSafeZone = false;
            Debug.Log("Player left safe zone");
        }
    }
}