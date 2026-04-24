using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private TextMeshProUGUI deathMessage;
    [SerializeField] private GameObject sharkBlood;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(HandleDeath());
        }
    }

    IEnumerator HandleDeath()
    {
        sharkBlood.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
}