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

    public byte hp = 3;
    // Start is called before the first frame update
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
        if (hp == 0)
        {
            // Play "Death" animation here!
           // Destroy(gameObject);
        }
        #endregion




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Damage Taken
        if (collision.gameObject.tag.Equals("PlayerBullet") == true) //There is no PlayerBullet tagged Object yet. Buse will handle that.
        {
            
            // Play "Hurt" animation here!
            Debug.Log("Damage taken");
            hp--;
            Debug.Log("Current hp:" + hp);
        }
        #endregion
    }
}
