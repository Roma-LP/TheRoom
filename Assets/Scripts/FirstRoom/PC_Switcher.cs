using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PC_Switcher : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerEnter;
    [SerializeField] private UnityEvent OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        PlayerEnter();
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerExit();
    }

    private void PlayerEnter()
    {
       // panelCamera.enabled = true;
        OnPlayerEnter?.Invoke();
        print("Enter!");
    }

    private void PlayerExit()
    {
       // panelCamera.enabled = false;
        print("Exit!");
        OnPlayerExit?.Invoke();
    }
}
