using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator),typeof(AudioSource))]
public class LevelInteract : MonoBehaviour, IInteractable
{
    public static event Action<bool> OnTurnLevel;
    [SerializeField] private AudioStore audioStore;

    private Animator animator;
    private bool isWorking;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        
        isWorking = false;
    }

    public void Interact()
    {
        if(isWorking)
        {
            animator.SetTrigger("TurnOff");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.FR_LevelOff));
            OnTurnLevel?.Invoke(false);
            isWorking = false;
        }
        else
        {
            animator.SetTrigger("TurnOn");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.FR_LevelOn));
            OnTurnLevel?.Invoke(true);
            isWorking = true;

        }
    }
}
