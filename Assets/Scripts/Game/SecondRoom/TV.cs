using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class TV : MonoBehaviour, IInteractable
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Canvas canvas;
    [SerializeField] private VideoStore videoStore;

    private bool isPlaying;
    private bool isCanvasShow;
    private AudioSource audioSource;

    private void Awake()
    {
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        switch (PlayerPrefs.GetString("Language"))
        {
            case "en_US":
                videoPlayer.clip = videoStore.GetVideoClipByType(VideoType.TaskEng);
                break;
            case "ru_RU":
                videoPlayer.clip = videoStore.GetVideoClipByType(VideoType.TaskRus);
                break;
        }
    }

    public void Interact()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            isPlaying = false;
        }
        else
        {
            if (!isCanvasShow) canvas.enabled = true;
            videoPlayer.Play();
            isPlaying = true;
        }
    }

    public void SetVideoClip(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
    }
    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
