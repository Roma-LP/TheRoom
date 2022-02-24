using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


[CreateAssetMenu(menuName = "ScriptableObjects/AudioStore")]
public class AudioStore : ScriptableObject
{
    [SerializeField, ArrayElementTitle("audioType")] private AudioField[] audioField;
    
    public AudioClip GetAudioClipByType(AudioType audioType)
    {
        return audioField.First(x => x.audioType == audioType).audioClip;
    }
}

public enum AudioType
{
    FloorWalk,
    FloorSprint,
    CarpetWalk,
    CarpetSprint,
    CorrectPassword,
    Open,
    Close,
    TryOpen,
    GlassWalk,
    GlassSprint,
    ModOn,
    ModOff,
    Click,
    DoubleClick,
    ComputerWorking,
    KeySound,
    SafeHandleOn,
}

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}
