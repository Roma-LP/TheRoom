using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Table_Enter : MonoBehaviour
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
        OnPlayerEnter?.Invoke();
        print("Enter!");
    }

    private void PlayerExit()
    {
        print("Exit!");
        OnPlayerExit?.Invoke();
    }
}
