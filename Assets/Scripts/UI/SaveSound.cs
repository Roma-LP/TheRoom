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
        commonVolume.onValueChanged.AddListener(delegate { ValueChangeCheckMusicVolume(); });
        effectVolume.onValueChanged.AddListener(delegate { ValueChangeCheckEffectVolume(); });
    }

    private void ValueChangeCheckMusicVolume()
    {
        PlayerPrefs.SetFloat("commonVolume", commonVolume.value);
        Debug.Log(commonVolume.value);
    }
    private void ValueChangeCheckEffectVolume()
    {
        PlayerPrefs.SetFloat("effectVolume", effectVolume.value);
        Debug.Log(effectVolume.value);
    }
}
