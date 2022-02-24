using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class LevelInteract : MonoBehaviour, IInteractable
{
    public static event Action<bool> OnTurnLevel;

    private Animator animator;
    private bool isWorking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isWorking = false;
    }

    public void Interact()
    {
        if(isWorking)
        {
            animator.SetTrigger("TurnOff");
            OnTurnLevel?.Invoke(false);
            isWorking = false;
        }
        else
        {
            animator.SetTrigger("TurnOn");
            OnTurnLevel?.Invoke(true);
            isWorking = true;
        }
    }
}
