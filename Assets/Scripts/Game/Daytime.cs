using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Daytime : MonoBehaviour
{
    //������ ����� ����� ����� ��������
    [SerializeField] private Gradient _directionalLightGradient; //�������� �����
    [SerializeField] private Gradient _ambientLightGradient; //�������� ������

    [SerializeField] private GlobalTimeManager _timeManager;

    [SerializeField] private Light _dirLight;

    private Vector3 _defaultAngles;
    

    private void Start()
    {
        _defaultAngles = _dirLight.transform.localEulerAngles;
    }

    private void Update()
    {
        //if (Application.isPlaying)
        //{
        //    _timeProgress += Time.deltaTime / _timeDayInSeconds;
        //}
        //if(_timeProgress > 1f)
        //{
        //    _timeProgress = 0;
        //}
        
        _dirLight.color = _directionalLightGradient.Evaluate(_timeManager.GetTimeProgress());
        RenderSettings.ambientLight = _ambientLightGradient.Evaluate(_timeManager.GetTimeProgress());

        _dirLight.transform.localEulerAngles = new Vector3(360f * _timeManager.GetTimeProgress(), _defaultAngles.x, _defaultAngles.z);
    }
}
