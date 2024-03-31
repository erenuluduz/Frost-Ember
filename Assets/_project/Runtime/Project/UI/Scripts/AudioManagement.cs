using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public static void PlayMusic(AudioSource audioSource)
    {
        // M�zi�i �al
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is null. Cannot play music.");
        }
    }
}
