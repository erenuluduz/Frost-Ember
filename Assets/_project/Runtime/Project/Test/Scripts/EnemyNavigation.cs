using Codice.CM.Client.Differences;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public Transform target;
    private GameObject player;
    private Rigidbody2D rb;
    private NavMeshAgent enemyNavMeshAgent;

    public float maxDistance = 4f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();

        if (enemyNavMeshAgent == null)
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyNavMeshAgent != null)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        enemyNavMeshAgent.SetDestination(target.position);
    }
}
