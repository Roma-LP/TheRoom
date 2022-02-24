using System;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class WUR_Input : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private UnityEvent OnOpenedDoor;

    private string password = "2314";
    private StringBuilder currentInput;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentInput = new StringBuilder("0000");
    }

    public enum ColorOfButton
    {
        red     = 0,
        yellow  = 1,
        green   = 2,
        blue    = 3,
        orange  = 4,
        purple  = 5,
    }
    public void ClickButton(string hit)
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Click));
        switch (Enum.Parse<ColorOfButton>(hit))
        {
            case ColorOfButton.red:
                {
                    ReadInputClick((int)ColorOfButton.red);
                    print(currentInput);
                    print("red");
                }
                break;
            case ColorOfButton.yellow:
                {
                    ReadInputClick((int)ColorOfButton.yellow);
                    print(currentInput);
                    print("yellow");
                }
                break;
            case ColorOfButton.green:
                {
                    ReadInputClick((int)ColorOfButton.green);
                    print(currentInput);
                    print("green");
                }
                break;
            case ColorOfButton.blue:
                {
                    ReadInputClick((int)ColorOfButton.blue);
                    print(currentInput);
                    print("blue");
                }
                break;
            case ColorOfButton.orange:
                {
                    ReadInputClick((int)ColorOfButton.orange);
                    print(currentInput);
                    print("orange");
                }
                break;
            case ColorOfButton.purple:
                {
                    ReadInputClick((int)ColorOfButton.purple);
                    print(currentInput);
                    print("purple");
                }
                break;
        }
        CheckPassword();
    }

    private void CheckPassword()
    {
        if (currentInput.Length < 4)
            return;

        if(currentInput.Equals(password))
        {
            OnOpenedDoor?.Invoke();
            print("correct!");
        }
    }

    private void ReadInputClick(int number)
    {
        currentInput.Append(number);
        currentInput.Remove(0, 1);  // remove first number to save 4-signs password
    }
}