using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    [SerializeField] private UnityEvent onMenuShow;  
    [SerializeField] private UnityEvent onMenuHide;  

    private bool isMenuShowing;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            if(isMenuShowing)
                MenuHide();
            else
                MenuShow();
        }
    }

    public void MenuHide()
    {
        menu.enabled = false;
        isMenuShowing = false;
        Time.timeScale = 1f;
        onMenuHide?.Invoke();
    }
    public void MenuShow()
    {
        menu.enabled = true;
        isMenuShowing = true;
        Time.timeScale = 0f;
        onMenuShow?.Invoke();
    }
}
