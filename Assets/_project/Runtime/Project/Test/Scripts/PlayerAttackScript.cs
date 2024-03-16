using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    public GameObject playerBullet;
    public Transform bulletSpawnPoint;

    public void OnClickAttack()
    {
        Instantiate(playerBullet, bulletSpawnPoint.position, Quaternion.identity);

    }
}
