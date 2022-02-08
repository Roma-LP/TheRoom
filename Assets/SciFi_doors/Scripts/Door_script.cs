using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door_script : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private Animator animator;
    [SerializeField] private WUR_Input input;
    [SerializeField] bool isDoorOpen = true;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("No animator component on this script!", gameObject);
            }
        }
    }

    void OnTriggerEnter()
    {
        if (isDoorOpen)
        {
            animator.SetTrigger("Open");
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.OpenSlideDoor));
        }
        else
        {


            switch (input.isLockOn)
            {
                case true:
                    animator.SetTrigger("TryOpen");
                    audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpenSlideDoor));
                    break;
                case false:
                    animator.SetTrigger("Open");
                    audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.OpenSlideDoor));
                    break;
            }
        }
    }

    void OnTriggerExit()
    {
        switch (input.isLockOn)
        {
            case true:
                
                break;
            case false:
                animator.SetTrigger("Close");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CloseSlideDoor));
                break;
        }
    }
}
