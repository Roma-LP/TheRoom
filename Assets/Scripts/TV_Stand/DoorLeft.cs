using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeft : MonoBehaviour , IInteractable
{
    [SerializeField] private Animator animator;

    private bool isOpen = false;
    public void Interact()
    {
        if (isOpen)
        {
            animator.Play("CloseLeft");
            isOpen = false;
        }
        else
        {
            animator.Play("OpenLeft");
            isOpen = true;
        }
    }
}
