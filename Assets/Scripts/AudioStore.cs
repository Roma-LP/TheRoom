using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AudioStore", order = 1)]
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
    WUR_ButtonClick,
    CorrectPassword,
    OpenSlideDoor,
    CloseSlideDoor,
    TryOpenSlideDoor,
    GlassWalk,
    GlassSprint,
    SpaceSound,
    FR_LevelOn,
    FR_LevelOff,
    Computer_Working,
    MouseClick,
    MouseDoubleClick
}

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}
