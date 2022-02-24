using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRight : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;

    private bool isOpen = false;
    public void Interact()
    {
        if (isOpen)
        {
            animator.Play("CloseRight");
            isOpen = false;
        }
        else
        {
            animator.Play("OpenRight");
            isOpen = true;
        }
    }
}
