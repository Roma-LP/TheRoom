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

    private void OnDestroy()
    {
        OnPlayClip -= PlayClip;
    }
}
