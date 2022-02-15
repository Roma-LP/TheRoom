using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator),typeof(AudioSource))]
public class LevelInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent<bool> OnTurnLevel;
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
        switch (isWorking)
        {
            case true:
                animator.SetTrigger("TurnOff");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType());
                OnTurnLevel?.Invoke(false);
                isWorking = false;
                break;
            case false:
                animator.SetTrigger("TurnOn");
                OnTurnLevel?.Invoke(true);
                isWorking = true;
                break;
        }
    }
}
