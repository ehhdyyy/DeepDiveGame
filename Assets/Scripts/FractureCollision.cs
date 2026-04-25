using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FractureCollision handles player collision with the fracture object. When hit, checks requirements for winning the game.
public class FractureCollision : MonoBehaviour
{
    [SerializeField] private GameObject winScreenUI;

    // Handle collision with player and check if they have enough fish and all upgrades to win the game
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
