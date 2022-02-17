using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorWithKeys : MonoBehaviour
{
    [SerializeField] private ItemType[] keysNeed;
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private Animator animator;
    [SerializeField] private MyInventory inventory;
    [SerializeField] bool isDoorOpen = true;
    [SerializeField] CanvasWhatNeed canvasWhatNeed;

    private AudioSource audioSource;
    private bool isLockOn = true;
    private bool isCheckedPassword;

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
            if (!isCheckedPassword)
            {
                if (!isKeysPicked())
                    canvasWhatNeed.WhatNeedBlinks(keysNeed);
            }
            
                switch (isLockOn)
                {
                    case true:
                        animator.SetTrigger("TryOpen");
                        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpenSlideDoor));
                        break;
                    case false:
                        animator.SetTrigger("Open");
                        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.OpenSlideDoor));
                        break;
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
        isCheckedPassword = true;
    }

    private bool isKeysPicked()
    {
        for (byte i = 0; i < keysNeed.Length;i++)
        {
            if (inventory.IsItemPicked(keysNeed[i]))
                continue;
            else
                return false;
        }
        Open();
        return true;
    }
}
