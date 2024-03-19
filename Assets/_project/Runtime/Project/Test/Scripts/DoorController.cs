using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public CellController cellController; // CellController'a eriþmek için referans
    private void Start()
    {
        // cellController'a referans atamasý yapýlýyor
        cellController = GameObject.FindObjectOfType<CellController>();


        // CellController referansý alýnmýþ mý diye kontrol et
        if (cellController == null)
        {
            Debug.LogError("CellController referansý atanmamýþ!");
            return; // Referans atanmamýþsa, kodun devamýný çalýþtýrmaya gerek yok
        }
    }

    private void Update()
    {
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        // enemyCount ve enemyGroupCount deðerlerini kontrol et
        if (cellController.enemyCount == 0 && cellController.enemyGroupCount == 0)
        {
            // Kapý açýldý mesajýný yazdýr
            Debug.Log("Kapý açýldý");
        }
        else
        {
            Debug.Log("Kapý açýlmadý. enemyCount: " + cellController.enemyCount + ", enemyGroupCount: " + cellController.enemyGroupCount);
        }
    }
}
