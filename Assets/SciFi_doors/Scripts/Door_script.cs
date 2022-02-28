using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Door_script : MonoBehaviour
{
    [SerializeField] private AudioStore audioStore;
    [SerializeField] private Animator animator;
    [SerializeField] bool isDoorOpen = true;

    private KeysNeed keysNeed;
    private AudioSource audioSource;
    private bool isLockOn = true;
    private bool isKeysNeeds;

    private void Awake()
    {
        isKeysNeeds = TryGetComponent<KeysNeed>(out keysNeed);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("commonVolume");
        GlobalEventManager.OnCommonVolumeChange += SetVolume;
    }

    void Start()
    {
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
            audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Open));
        }
        else
        {
            if (isKeysNeeds)
            {
                keysNeed.CheckInventory();
            }
            if (isLockOn)
            {
                animator.SetTrigger("TryOpen");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.TryOpen));
            }
            else
            {
                animator.SetTrigger("Open");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Open));
            }
        }
    }

    void OnTriggerExit()
    {
        switch (isLockOn)
        {
            case true:

                break;
            case false:
                animator.SetTrigger("Close");
                audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.Close));
                break;
        }
    }

    private void SetVolume(float volume) => audioSource.volume = volume;

    public void Open()
    {
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.CorrectPassword));
        isLockOn = false;
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnCommonVolumeChange -= SetVolume;
    }
}
