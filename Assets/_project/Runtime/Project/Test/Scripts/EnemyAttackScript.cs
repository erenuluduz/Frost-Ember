using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.Serialization;
using static PlasticPipe.Server.MonitorStats;
using Random = System.Random;

public class EnemyAttackScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject player;

    public Transform bulletSpawnPoint;

    [SerializeField]private float timer;
    [SerializeField]private float maxDistance = 10;
    [SerializeField]private float distance;
    GameObject bullet;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //player değişkenine "Player" tag'ine sahip GameObject'i tanımlıyor
    }

    void Update()
    {
        if (IsPlayerInRange())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = UnityEngine.Random.Range(2,5);
                shoot();
            }
        }
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    private bool IsPlayerInRange()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < maxDistance)
        {
            return true;
        }

        return false;

    }

}
