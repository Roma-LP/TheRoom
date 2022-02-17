using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class BoardAnimManager : MonoBehaviour , IInteractable
{
    [SerializeField] private UnityEvent<string> OnClickButton;
    [SerializeField] private bool isOpenAtStart;
    private Animator animator;
    private bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (isOpenAtStart)
        {
            if (!isOpen)
            {
                animator.SetTrigger("Open");
                isOpen = true;
                DeskSonds.TriggerOnPlayClip("Open");
            }
            else
            {
                animator.SetTrigger("Close");
                isOpen = false;
                DeskSonds.TriggerOnPlayClip("Close");
            }
        }
        else
        {
            animator.SetTrigger("TryOpen");
            DeskSonds.TriggerOnPlayClip("TryOpen");
        }
    }

    public void OpenBoard()
    {
        if (!isOpen)
        {
            animator.SetTrigger("Open");
            isOpen = true;
            isOpenAtStart = true;
            DeskSonds.TriggerOnPlayClip("Open");
        }
    }
}
