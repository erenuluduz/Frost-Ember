using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    public GameObject playerBullet;
    public Transform bulletSpawnPoint;

    private void Awake()
    {
        playerBullet = GameObject.FindGameObjectWithTag("PlayerBullet");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            Instantiate(playerBullet, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
