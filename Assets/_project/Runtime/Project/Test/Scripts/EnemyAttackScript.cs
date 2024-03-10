using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using static PlasticPipe.Server.MonitorStats;

public class EnemyAttackScript : MonoBehaviour
{
    private bool attack = false;

    public GameObject bulletPrefab;
    private GameObject player;

    public Transform bulletSpawnPoint;

    private float timer;
    GameObject bullet;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //player deðiþkenine "Player" tag'ine sahip GameObject'i tanýmlýyor
    }

    void Update()
    {
        if (attack)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player entered attack area");
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exit attack area");
            attack = false;
        }
    }

}
