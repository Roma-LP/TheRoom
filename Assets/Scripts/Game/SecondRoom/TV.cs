using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Canvas canvas;

    private bool isPlaying;
    private bool isCanvasShow;
    

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
}
