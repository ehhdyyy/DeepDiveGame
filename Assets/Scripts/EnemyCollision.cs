using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// EnemyCollision handles the player's collision with shark enemies. When collision is detected, it triggers a death sequence.
public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private TextMeshProUGUI deathMessage;
    [SerializeField] private GameObject sharkBlood;

    // Handle collsion with player and trigger death sequence
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(HandleDeath());
        }
    }

    // Show blood effect, then display death screen
    IEnumerator HandleDeath()
    {
        sharkBlood.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
}