using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSound : MonoBehaviour
{
    [SerializeField] public Slider commonVolume;
    [SerializeField] public Slider effectVolume;


    private void Start()
    {
        commonVolume.value = PlayerPrefs.GetFloat("commonVolume");
        effectVolume.value = PlayerPrefs.GetFloat("effectVolume");
        commonVolume.onValueChanged.AddListener(delegate { ValueChangeCheckCommonVolume(); });
        effectVolume.onValueChanged.AddListener(delegate { ValueChangeCheckEffectVolume(); });
    }

    private void ValueChangeCheckCommonVolume()
    {
        PlayerPrefs.SetFloat("commonVolume", commonVolume.value);
        GlobalEventManager.TriggerOnCommonVolumeChange(commonVolume.value);
        print(commonVolume.value);
    }
    private void ValueChangeCheckEffectVolume()
    {
        PlayerPrefs.SetFloat("effectVolume", effectVolume.value);
        print(effectVolume.value);
    }
}
