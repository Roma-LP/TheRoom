using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AudioStore", order = 1)]
[CreateAssetMenu(menuName = "ScriptableObjects/AudioStore")]
public class AudioStore : ScriptableObject
{
    [SerializeField] private AudioField[] audioField;
    
    public AudioClip GetAudioClipByType(string audioType)
    {
        return audioField.First(x => x.audioType.ToString() == audioType).audioClip;
    }
}

public enum AudioType { Floor, Carpet }

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}
