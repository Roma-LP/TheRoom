using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeft : MonoBehaviour , IInteractable
{
    [SerializeField] private Animator animator;

    private bool isOpen;
    public void Interact()
    {
        if (isOpen)
        {
            animator.SetTrigger("CloseLeft");
            isOpen = false;
        }
        else
        {
            animator.SetTrigger("OpenLeft");
            isOpen = true;
        }
    }
}
