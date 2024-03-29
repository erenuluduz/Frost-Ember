
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform target;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private float shootInterval = 2f;

    private float timer;

    public float hp = 3;
    private bool istargetNotNull;

    void Start()
    {
        istargetNotNull = target != null;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        timer = shootInterval; // Start timer at shootInterval
    }

    void Update()
    {
        if (istargetNotNull)
        {
            agent.SetDestination(target.position);
            if (IsPlayerInRange())
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp--;
            IsDead();
        }
    }

    private void Shoot()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = shootInterval; // Reset the timer

            // Instantiate the bullet prefab at the bullet spawn point
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // Calculate the direction towards the player
            Vector3 direction = (target.position - transform.position).normalized;

            // Set the bullet's velocity to move towards the player
            float bulletSpeed = 0;
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, target.position) < maxDistance;
    }

    private void IsDead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}