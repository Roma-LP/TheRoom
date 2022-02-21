using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class SafeManager : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private TMP_Text inputText;

    private string password = "1234";
    private StringBuilder currentInput;
    private AudioSource audioSource;
    private Animator animator;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        currentInput = new StringBuilder(4);
    }

    public void ClickButton(string hit)
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.SafeBT_Click));
        currentInput.Append(hit);
        UpdateInput();
        CheckPassword();
    }

    private void CheckPassword()
    {
        if (currentInput.Length < 4)
            return;

        if (currentInput.Equals(password))
        {
            StartCoroutine(Correct());
            print("correct!");
            
        }
        else
        {
            StartCoroutine(UnCorrect());
        }
    }

    private void UpdateInput()
    {
        inputText.text = currentInput.ToString();
    }

    private IEnumerator UnCorrect()
    {
        inputText.color = Color.red;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpenSlideDoor));
        yield return new WaitForSeconds(1f);
        currentInput.Clear();
        inputText.color = Color.yellow;
        UpdateInput();
    }
    private IEnumerator Correct()
    {
        inputText.color = Color.green;
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Open");
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.SafeHandleOn));
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.SafeOpen));
        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
