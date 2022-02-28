using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OpenCloseManager : MonoBehaviour , IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioStore audioStore;

    private bool isOpen;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
    }
    public void Interact()
    {
        if (isOpen)
        {
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Close));
            animator.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Open));
            animator.SetTrigger("Open");
            isOpen = true;
        }
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
