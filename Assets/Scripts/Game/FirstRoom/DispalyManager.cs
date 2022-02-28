using Cinemachine;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DispalyManager : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnEnterDisplay;
    [SerializeField] private UnityEvent OnExitDisplay;
    [SerializeField] private UnityEvent OnOpenedDoor;
    [SerializeField] private Canvas displayCanvas;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private AudioStore audioStore;

    private AudioSource audioSource;

    private byte[] password = { 9, 4, 3, 8 }; // A , C , F , I
    //private byte[] password = { 3, 3, 3, 3 };
    private byte[] currentInput = new byte[4];

    public static event Action<PasswordLetter, byte> OnClickPassword;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        LevelInteract.OnTurnLevel += DisplayMod;
        OnClickPassword += CheckPassword;
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
    }

    public static void TriggerOnClickPassword(PasswordLetter letter, byte value)
    {
        OnClickPassword.Invoke(letter, value);
    }
    public void Interact()
    {
        if (displayCanvas.enabled)
        {
            virtualCamera.enabled = true;
            OnEnterDisplay?.Invoke();
        }
    }

    public void ExitDispaly()
    {
        virtualCamera.enabled = false;
        StartCoroutine(WaitTwoSec());
    }

    public void DisplayMod(bool isLevelOn)
    {
        if (isLevelOn)
        {
            displayCanvas.enabled = true;
            audioSource.clip = audioStore.GetAudioClipByType(AudioType.ComputerWorking);
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.ModOn));
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            StartCoroutine(WaitWhileAudioPlay());
        }
    }

    public void PlayMouseClick()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Click));
    }
    public void PlayMouseDoubleClick()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.DoubleClick));
    }
    public void PlayKeySound()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.KeySound));
    }

    private void CheckPassword(PasswordLetter lette, byte value)
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

        if (currentInput.SequenceEqual(password))
        {
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
            OnOpenedDoor?.Invoke();
            print("correct!");
        }
    }

    private void OnDestroy()
    {
        LevelInteract.OnTurnLevel -= DisplayMod;
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
        OnClickPassword -= CheckPassword;
    }

    IEnumerator WaitTwoSec()
    {
        yield return new WaitForSeconds(2f);
        OnExitDisplay?.Invoke();
    }

    IEnumerator WaitWhileAudioPlay()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.ModOff));
        yield return new WaitForSeconds(audioStore.GetAudioClipByType(AudioType.ModOff).length);
        displayCanvas.enabled = false;
        audioSource.Stop();
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

}

public enum PasswordLetter
{
    A, F, C, I
}
