using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioStore audioStore;

    private AudioSource audioSource;
    private KeysNeed keysNeed;
    private Animator animator;
    private bool isLockOn = true;
    private bool isKeysNeeds;

    private void Awake()
    {
        isKeysNeeds = TryGetComponent<KeysNeed>(out keysNeed);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (isKeysNeeds)
        {
            keysNeed.CheckInventory();
        }

        if(isLockOn)
        {
            animator.SetTrigger("TryOpen");
        }
        else
        {
            animator.SetTrigger("Open");
        }
    }

    public void Open()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
        isLockOn = false;
    }

}
