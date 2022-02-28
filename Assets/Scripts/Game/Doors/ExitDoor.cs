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
    private bool isCoroutineWorking;

    private void Awake()
    {
        isKeysNeeds = TryGetComponent<KeysNeed>(out keysNeed);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
    }

    public void Interact()
    {
        if (isKeysNeeds)
        {
            if (!isCoroutineWorking)
                StartCoroutine(CheckInventory());
        }

        if(isLockOn)
        {
            animator.SetTrigger("TryOpen");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpen));
        }
        else
        {
            animator.SetTrigger("Open");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Open));
        }
    }

    public void Open()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
        isLockOn = false;
    }

    IEnumerator CheckInventory()
    {
        isCoroutineWorking = true;
        keysNeed.CheckInventory();
        yield return new WaitForSeconds(3f);
        isCoroutineWorking = false;
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
