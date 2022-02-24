using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideSounds : MonoBehaviour
{
    private bool isSoundPlay;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartSound()
    {
        if(!isSoundPlay)
        {
            isSoundPlay = true;
            audioSource.Play();
        }
    }
}
