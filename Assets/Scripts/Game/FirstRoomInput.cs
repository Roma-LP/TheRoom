using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using Cinemachine;
using TMPro;

public class FirstRoomInput : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;
    public UnityEvent OnPlayerExit;
    public UnityEvent OnCorrectPassword;
    [SerializeField] private CinemachineVirtualCamera panelCamera;


    private bool[] correctPassword = {
        false, false,  true,  true,  true,  true,  true,  true,  true, false,
         true,  true, false, false, false,  true,  true, false,  true,  true,
        false,  true, false, false, false, false,  true, false,  true, false,
        false,  true,  true,  true,  true,  true,  true,  true,  true, false,
        false, false,  true,  true, false,  true,  true, false, false, false,
    };
    //private bool[] correctPassword = {
    //     true, false, false, false, false, false, false, false, false, false,
    //    false, false, false, false, false, false, false, false, false, false,
    //    false, false, false, false, false, false, false, false, false, false,
    //    false, false, false, false, false, false, false, false, false, false,
    //    false, false, false, false, false, false, false, false, false, false,
    //};

    private bool[] inputPassword;

    void Start()
    {
        inputPassword = new bool[50];
    }
    public void OnClickButton(string nameButton)
    {
        inputPassword[int.Parse(nameButton) - 1] = !inputPassword[int.Parse(nameButton) - 1];
        if (CheckPassword())
        {
            OnCorrectPassword?.Invoke();
            print("correct!");
        }
    }
    public void OnClickRightButton(TMP_Text text)
    {
        if(String.IsNullOrEmpty(text.text))
        {
        text.text = "X";
        }
        else
            text.text = String.Empty;
    }

    private bool CheckPassword()
    {
        return correctPassword.SequenceEqual(inputPassword);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerEnter();
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerExit();
    }

    private void PlayerEnter()
    {
        panelCamera.enabled = true;
        OnPlayerEnter?.Invoke();
    }

    private void PlayerExit()
    {
        panelCamera.enabled = false;
        OnPlayerExit?.Invoke();
    }
}
