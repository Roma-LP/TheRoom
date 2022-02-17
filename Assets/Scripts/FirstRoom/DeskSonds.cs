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
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.BoardOpen));
                break;
            case "Close":
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.BoardClose));
                break;
            case "TryOpen":
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.BoardTryOpen));
                break;
        }
    }

    private void OnDestroy()
    {
        OnPlayClip -= PlayClip;
    }
}
