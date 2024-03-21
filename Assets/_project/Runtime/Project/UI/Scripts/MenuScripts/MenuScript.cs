using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{
    public Image canvasGroup;
    public float fadeDuration = 2f;

    public void OnClickPlay()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.color = new Color(0f, 0f, 0f,0f);
        // Siyah ekranı yavaşça açma animasyonu
        canvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            SceneManager.LoadScene("Launcher");
        });
    }
}
