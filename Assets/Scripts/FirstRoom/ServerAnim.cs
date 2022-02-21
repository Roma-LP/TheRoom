using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerAnim : MonoBehaviour , IInteractable
{
    [SerializeField] private Animator animator;

    private bool isOpen;

    public void Interact()
    {
        if(isOpen)
        {
            animator.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            animator.SetTrigger("Open");
            isOpen = true;
        }
    }
}
