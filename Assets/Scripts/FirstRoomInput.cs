using UnityEngine;
using System.Linq;
using System;

public class FirstRoomInput : MonoBehaviour
{
    public bool isLockOn { get; private set; }

    private bool[] correctPassword = {
        false, false,  true,  true,  true,  true,  true,  true,  true, false,
         true,  true, false, false, false,  true,  true, false,  true,  true,
        false,  true, false, false, false, false,  true, false,  true, false,
        false,  true,  true,  true,  true,  true,  true,  true,  true, false,
        false, false,  true,  true, false,  true,  true, false, false, false,
    };

    private bool[] inputPassword; /*= {
        true, false,  true,  true,  true,  true,  true,  true,  true, false,
         true,  true, false, false, false,  true,  true, false,  true,  true,
        false,  true, false, false, false, false,  true, false,  true, false,
        false,  true,  true,  true,  true,  true,  true,  true,  true, false,
        false, false,  true,  true, false,  true,  true, false, false, false,
    };*/
    void Start()
    {
        print("correctPassword.Length - " + correctPassword.Length);
        inputPassword = new bool[50];
        print("inputPassword.Length - " +inputPassword.Length);
        print("CheckPassword - "+CheckPassword());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickButton(string nameButton)
    {
        inputPassword[int.Parse(nameButton)-1] = !inputPassword[int.Parse(nameButton)-1];
        if(CheckPassword())
        {
            isLockOn = false;
            print("correct!");
        }
    }

    private bool CheckPassword()
    {
        //print("correctPassword.SequenceEqual(inputPassword) - " + correctPassword.SequenceEqual(inputPassword));   
        return correctPassword.SequenceEqual(inputPassword);
    }

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnTriggerExit(Collider other)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Chehehehehe(string str)
    {
        print(str);
    }
}
