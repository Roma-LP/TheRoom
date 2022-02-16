using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cinemachine;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class DispalyManager : MonoBehaviour , IInteractable
{
    [SerializeField] private UnityEvent OnEnterDisplay;
    [SerializeField] private UnityEvent OnExitDisplay;
    [SerializeField] static private UnityEvent OnOpenedDoor;
    [SerializeField] private Canvas displayCanvas;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private AudioStore audioStore;

    private AudioSource audioSource;

    private static byte[] password = { 9, 4, 3, 8 }; // A , C , F , I
    private static byte[] currentInput = new byte[4];

    //private static event Action<string, byte> OnClickPassword;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        LevelInteract.OnTurnLevel += DisplayMod;
    }

    //private static void TriggerOnClickPassword(string name, byte value)
    //{
    //    OnClickPassword.Invoke(name, value);
    //}
    public void Interact()
    {
        virtualCamera.enabled = true;
        OnEnterDisplay?.Invoke();
    }

    public void ExitDispaly()
    {
        virtualCamera.enabled = false;
        StartCoroutine(WaitTwoSec());
    }

    public void DisplayMod(bool mod)
    {
        switch(mod)
        {
            case true:
                displayCanvas.enabled = true;
                audioSource.clip = audioStore.GetAudioClipByType(AudioType.Computer_Working);
                audioSource.loop = true;
                audioSource.Play();
                break;
            case false:
                displayCanvas.enabled= false;
                audioSource.Stop();
                break;
        }
    }

    public void PlayMouseClick()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.MouseClick));
    }
    public void PlayMouseDoubleClick()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.MouseDoubleClick));
    }

    public static void CheckPassword(PasswordLetter lette, byte value)
    { // A , C , F , I
        switch (lette)
        {
            case PasswordLetter.A:
                currentInput[0] = value;
                break;
            case PasswordLetter.F:
                currentInput[2] = value;
                break;
            case PasswordLetter.C:
                currentInput[1] = value;
                break;
            case PasswordLetter.I:
                currentInput[3] = value;
                break;
        }

        if(currentInput.SequenceEqual(password))
        {
            OnOpenedDoor?.Invoke();
            print("correct!");
        }
    }

    private void OnDestroy()
    {
        LevelInteract.OnTurnLevel -= DisplayMod;
    }

    IEnumerator WaitTwoSec()
    {
        yield return new WaitForSeconds(2f);
        print("");
        OnExitDisplay?.Invoke();
    }
}

public enum PasswordLetter
{
    A,F,C,I
}
