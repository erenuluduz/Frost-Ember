using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public CellController cellController; // CellController'a eri�mek i�in referans
    private void Start()
    {
        // cellController'a referans atamas� yap�l�yor
        cellController = GameObject.FindObjectOfType<CellController>();


        // CellController referans� al�nm�� m� diye kontrol et
        if (cellController == null)
        {
            Debug.LogError("CellController referans� atanmam��!");
            return; // Referans atanmam��sa, kodun devam�n� �al��t�rmaya gerek yok
        }
    }

    private void Update()
    {
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        // enemyCount ve enemyGroupCount de�erlerini kontrol et
        if (cellController.enemyCount == 0 && cellController.enemyGroupCount == 0)
        {
            // Kap� a��ld� mesaj�n� yazd�r
            Debug.Log("Kap� a��ld�");
        }
        else
        {
            Debug.Log("Kap� a��lmad�. enemyCount: " + cellController.enemyCount + ", enemyGroupCount: " + cellController.enemyGroupCount);
        }
    }
}
