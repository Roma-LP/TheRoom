using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;
using TMPro;

public class EndGameCanvasManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Canvas canvas;
    [SerializeField] private VideoStore videoStore;
    [SerializeField] private GameObject Text_1;
    [SerializeField] private GameObject Text_2;

    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
        //videoPlayer.SetDirectAudioVolume(0, PlayerPrefs.GetFloat("commonVolume"));
    }
    public void StartVideo()
    {
        canvas.enabled = true;
        rawImage.enabled = true;
        switch (PlayerPrefs.GetString("Language"))
        {
            case "en_US":
                videoPlayer.clip = videoStore.GetVideoClipByType(VideoType.AtomicHeartEng);
                break;
            case "ru_RU":
                videoPlayer.clip = videoStore.GetVideoClipByType(VideoType.AtomicHeartRus);
                break;
        }
        videoPlayer.Play();
        StartCoroutine(WaitVideoPlayer());
    }

    public void StartEndGame()
    {
        animator.SetTrigger("End");
        canvas.enabled = true;
    }

    IEnumerator WaitVideoPlayer()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        SceneManager.LoadScene("Menu");
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
