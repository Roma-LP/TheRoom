using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class InputButton : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField] private UnityEvent<string> OnClickButton;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        animator.SetTrigger("Click");
        OnClickButton?.Invoke(name);
    }
}
