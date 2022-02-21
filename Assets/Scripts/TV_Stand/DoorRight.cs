using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRight : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;

    private bool isOpen;
    public void Interact()
    {
        if (isOpen)
        {
            animator.SetTrigger("CloseRight");
            isOpen = false;
        }
        else
        {
            animator.SetTrigger("OpenRight");
            isOpen = true;
        }
    }
}
