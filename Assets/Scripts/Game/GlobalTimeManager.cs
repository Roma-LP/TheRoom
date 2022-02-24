using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimeManager : MonoBehaviour
{
    [SerializeField, Range(1, 3600)] private float timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] private float _timeProgress;

    private void Update()
    {
        if (Application.isPlaying)
        {
            _timeProgress += Time.deltaTime / timeDayInSeconds;
        }
        if (_timeProgress > 1f)
        {
            _timeProgress = 0;
        }
    }
    public float GetTimeProgress() => _timeProgress;
}
