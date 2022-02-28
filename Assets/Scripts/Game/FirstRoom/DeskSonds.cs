using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class DeskSonds : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;

    private static event Action<string> OnPlayClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
        OnPlayClip += PlayClip;
    }

    public static void TriggerOnPlayClip(string name) => OnPlayClip?.Invoke(name);

    private void PlayClip(string name)
    {
        switch(name)
        {
            case "Open":
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Open));
                break;
            case "Close":
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Close));
                break;
            case "TryOpen":
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpen));
                break;
        }
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        OnPlayClip -= PlayClip;
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
