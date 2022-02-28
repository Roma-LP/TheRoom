using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "ScriptableObjects/VideoStore")]
public class VideoStore : ScriptableObject
{
    [SerializeField, ArrayElementTitle("videoType")] private VideoField[] videoField;

    public VideoClip GetVideoClipByType(VideoType videoType)
    {
        return videoField.First(x => x.videoType == videoType).videoClip;
    }
}


public enum VideoType
{
    TaskEng,
    TaskRus,
    AtomicHeartEng,
    AtomicHeartRus
}

[Serializable]
public class VideoField
{
    public VideoType videoType;
    public VideoClip videoClip;
}
