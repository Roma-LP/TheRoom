using UnityEngine;
using System.Linq;

public class FirstRoomInput : MonoBehaviour
{
    private bool[] correctPassword = {
        false, false,  true,  true,  true,  true,  true,  true,  true, false,
         true,  true, false, false, false,  true,  true, false,  true,  true,
        false,  true, false, false, false, false,  true, false,  true, false,
        false,  true,  true,  true,  true,  true,  true,  true,  true, false,
        false, false,  true,  true, false,  true,  true, false, false, false,
    };

    private bool[] inputPassword;
    void Start()
    {
        print(correctPassword.Length);
        inputPassword = new bool[50];
        print(inputPassword.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClickButton(string nameButton)
    {

    }

    private bool CheckPassword()
    {
        
    }
}
