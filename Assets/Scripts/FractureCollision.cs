using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureCollision : MonoBehaviour
{
    [SerializeField] private GameObject winScreenUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && FishManager.Instance.GetFish() >= 10 && UpgradeShop.Instance.IsMaxedOut())
        {
            Debug.Log("Player collided with fracture object.");
            winScreenUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
