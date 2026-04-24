using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public float speed = 5f;
    public float rotationSpeed = 5f;
    public float chaseDistance = 25f;
    public float pointReachedDistance = 1f;

    private int currPointIdx = 0;

    [SerializeField] private Transform spawnZoneCenter;
    [SerializeField] private float spawnZoneRadius = 5f;

    void Update()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        // Can never have less than 2.a
        if (player == null || patrolPoints.Length < 2) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            MoveTowards(player.position);
        }
        else
        {
            Transform targetPoint = patrolPoints[currPointIdx];

            MoveTowards(targetPoint.position);

            if (Vector3.Distance(transform.position, targetPoint.position) < pointReachedDistance)
            {
                if (currPointIdx == 0)
                {
                    currPointIdx = 1;
                }
                else if (currPointIdx == patrolPoints.Length - 1)
                {
                    currPointIdx = patrolPoints.Length - 2;
                }
                else
                {
                    currPointIdx += Random.Range(0, 2) == 0 ? -1 : 1;
                }
            }
        }
    }

    void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Vector3 newPos = transform.position + direction * speed * Time.deltaTime;

        float distanceToSpawn = Vector3.Distance(newPos, spawnZoneCenter.position);

        if (distanceToSpawn > spawnZoneRadius)
        {
            transform.position = newPos;
        }

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}