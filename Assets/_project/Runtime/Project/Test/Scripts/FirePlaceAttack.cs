using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceAttack : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject FireBall;
    float timebetween;
    public float startimebetween;

    void Start()
    {
        timebetween = startimebetween;  
    }

   
    void Update()
    {
        if (timebetween <= 0)
        {
            Instantiate(FireBall, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            timebetween = startimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
