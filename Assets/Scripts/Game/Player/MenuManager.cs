using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas menu;
    [SerializeField] private UnityEvent onMenuShow;  
    [SerializeField] private UnityEvent onMenuHide;  

    private bool isMenuShowing;
    private bool isMenuCanOpen=true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuCanOpen)
            {
                if (isMenuShowing)
                    MenuHide();
                else
                    MenuShow();
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
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

    public void OffMenuWork() => isMenuCanOpen = false;

}
