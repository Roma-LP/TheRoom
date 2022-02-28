using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerAnim : MonoBehaviour , IInteractable
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
        if(isOpen)
        {
            animator.SetTrigger("Close");
            audioSource.Stop();
            isOpen = false;
        }
        else
        {
            audioSource.clip = audioStore.GetAudioClipByType(AudioType.Open);
            audioSource.Play();
            audioSource.loop = true;
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
