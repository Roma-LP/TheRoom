﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door_script : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private Animator animator;
    [SerializeField] bool isDoorOpen = true;

    private KeysNeed keysNeed;
    private AudioSource audioSource;
    private bool isLockOn = true;
    private bool isKeysNeeds;

    private void Awake()
    {
        isKeysNeeds = TryGetComponent<KeysNeed>(out keysNeed);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("No animator component on this script!", gameObject);
            }
        }
    }

    void OnTriggerEnter()
    {
        if (isDoorOpen)
        {
            animator.SetTrigger("Open");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.OpenSlideDoor));
        }
        else
        {
            if (isKeysNeeds)
            {
                keysNeed.CheckInventory();
            }
            if (isLockOn)
            {
                animator.SetTrigger("TryOpen");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpenSlideDoor));
            }
            else
            {
                animator.SetTrigger("Open");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.OpenSlideDoor));
            }
        }
    }

    void OnTriggerExit()
    {
        switch (isLockOn)
        {
            case true:

                break;
            case false:
                animator.SetTrigger("Close");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CloseSlideDoor));
                break;
        }
    }
    public void Open()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
        isLockOn = false;
    }
}
