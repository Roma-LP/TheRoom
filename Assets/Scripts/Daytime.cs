using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Daytime : MonoBehaviour
{
    //скрипт смены суток через градиент
    [SerializeField] private Gradient _directionalLightGradient; //градиент суток
    [SerializeField] private Gradient _ambientLightGradient; //градиент ночной

    [SerializeField, Range(1, 3600)] private float _timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] private float _timeProgress;

    [SerializeField] private Light _dirLight;

    private Vector3 _defaultAngles;

    private void Start()
    {
        _defaultAngles = _dirLight.transform.localEulerAngles;
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            _timeProgress += Time.deltaTime / _timeDayInSeconds;
        }
        if(_timeProgress > 1f)
        {
            _timeProgress = 0;
        }
        
        _dirLight.color = _directionalLightGradient.Evaluate(_timeProgress);
        RenderSettings.ambientLight = _ambientLightGradient.Evaluate(_timeProgress);

        _dirLight.transform.localEulerAngles = new Vector3(360f * _timeProgress, _defaultAngles.x, _defaultAngles.z);
    }
}
