using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    
    [SerializeField]
    public Transform target;
    [SerializeField]
    private Transform bulletSpawnPoint;
    
    [SerializeField]
    private GameObject bulletPrefab;

    

    [SerializeField]
    private float timer;
    [SerializeField]
    private float maxDistance = 10;
    [SerializeField]
    private float distance;

    public float hp = 3;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    void Update()
    {
        shoot();
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayerBullet") == true)
        {
            // Play "Hurt" animation here!
            hp--;
            IsDead();
        }
    }
    
    #region Attack
    private void shoot()
    {
        if (IsPlayerInRange())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = UnityEngine.Random.Range(2, 5);
                Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            }
        }
    }

    private bool IsPlayerInRange()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance < maxDistance)
        {
            return true;
        }

        return false;
    }
    #endregion

    private void IsDead()
    {
        if (hp <= 0)
        {
            // Play "Death" animation here!
            Destroy(gameObject);
        }
    }
    
}
