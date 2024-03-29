
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

    public float hp = 10;
    private bool istargetNotNull;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        istargetNotNull = target != null;
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (IsPlayerInRange())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = UnityEngine.Random.Range(2, 5);
                EnemyBullet instance = ObjectPooler.DequeueObject<EnemyBullet>("EnemyBullet");
                
                instance.transform.position = bulletSpawnPoint.transform.position;
                instance.gameObject.SetActive(true);
                instance.Initialize();
                //Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            }
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
