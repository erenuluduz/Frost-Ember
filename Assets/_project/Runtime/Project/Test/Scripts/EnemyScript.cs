using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public float hp = 3;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
    }
    void Update()
    {

        agent.SetDestination(target.position);
        #region Death
        if (hp <= 0)
        {
            // Play "Death" animation here!
            Destroy(gameObject);
        }
        #endregion




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region DamageTaken
        
        if (collision.gameObject.tag.Equals("PlayerBullet") == true)
        {
            
            // Play "Hurt" animation here!
            Debug.Log("Damage taken");
            hp--;
            Debug.Log("Current hp:" + hp);
        }
        #endregion
    }
    
}
