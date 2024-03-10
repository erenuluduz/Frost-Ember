using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{
    public byte hp = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
