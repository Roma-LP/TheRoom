using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndGameCanvasManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;
    public void StartVideo()
    {
        rawImage.enabled = true;
        videoPlayer.Play();
        StartCoroutine(WaitVideoPlayer());
    }

    IEnumerator WaitVideoPlayer()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
    }
}
