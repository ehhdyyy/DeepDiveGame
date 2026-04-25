using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CoinPickup handles the behavior of coin objects in the game. Handles player collision to collect coins as well as magnet effect to move coins towards players when in range. 
public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private AudioClip pickupAudio;
    [SerializeField] private ParticleSystem pickupEffect;

    private Transform player;
    private PlayerStats playerStats;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null){
            player = playerObj.transform;
            playerStats = playerObj.GetComponent<PlayerStats>();
        }
    }

    // Magnet effect to move coin towards player when in range
    void Update()
    {
        if(player == null || playerStats == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance <= playerStats.magnetRange)
        {
            float speed = moveSpeed + (playerStats.magnetRange - distance) * 1.2f;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    // Handle coin collection when player collides with it
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(coinValue);

            if(pickupAudio != null)
            {
                AudioSource.PlayClipAtPoint(pickupAudio, transform.position);
            }
            if(pickupEffect != null)
            {
                ParticleSystem fx = Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(fx.gameObject, fx.main.duration);
            }
            Destroy(gameObject);
            
        }
    }
}
