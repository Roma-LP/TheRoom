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
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
    }
    public void StartSound()
    {
        if(!isSoundPlay)
        {
            isSoundPlay = true;
            audioSource.Play();
        }
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
