using System;
using System.Text;
using UnityEngine;

public class WUR_Input : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float distanceRay;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioStore audioStore;

    private Ray ray;
    private RaycastHit hit;
    private bool isRayOn;
    private float currentDistanceRay;
    private ColorOfButton hitColorOfButton;

    private string password = "2314";
    private StringBuilder currentPassword;

    private void Awake()
    {
        currentDistanceRay = distanceRay;
        //audioSource = GetComponent<AudioSource>();
        currentPassword = new StringBuilder("0000");
    }

    private enum ColorOfButton
    {
        red     = 0,
        yellow  = 1,
        green   = 2,
        blue    = 3,
        orange  = 4,
        purple  = 5,
    }
    private void OnTriggerEnter(Collider other)
    {
        isRayOn = true;
        //if (other.gameObject.CompareTag("WUR_0"))
        //{
        //    MyRay();
        //    DrawRay();
        //    print("WUR_0");
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        isRayOn = false;
    }

    private void Update()
    {
        if (isRayOn)
        {
            MyRay();
            DrawRay();
            print("WUR_0");
        }
    }
    private void MyRay()
    {
        ray = playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(ray, out hit, currentDistanceRay, layerMask))
        {
            currentDistanceRay = hit.distance;
            if (Input.GetMouseButtonUp(0))
            {
                hitColorOfButton = Enum.Parse<ColorOfButton>(hit.collider.name);
                ClickButton(hit);
            }

            Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.blue);
        }

        if (hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.red);
            currentDistanceRay = distanceRay;
        }
    }

    //private void DrawRay()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        if (Physics.Raycast(ray, out hit, currentDistanceRay, layerMask))
    //        {
    //            currentDistanceRay = hit.distance;
    //            hitColorOfButton = Enum.Parse<ColorOfButton>(hit.collider.name);
    //            ClickButton(hit);
    //        }

    //        Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.blue);

    //        if (hit.transform == null)
    //        {
    //            Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.red);
    //            currentDistanceRay = distanceRay;
    //        }
    //    }

    //}

    private void ClickButton(RaycastHit hit)
    {
        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("Click");
        //audioSource.clip=audioStore.GetAudioClipByType(AudioType.WUR_ButtonClick);
        audioSource.PlayOneShot(audioStore.GetAudioClipByType(AudioType.WUR_ButtonClick));
        switch (Enum.Parse<ColorOfButton>(hit.collider.name))
        {
            case ColorOfButton.red:
                {
                    ReadInputClick((int)ColorOfButton.red);
                    print(currentPassword);
                    print("red");
                }
                break;
            case ColorOfButton.yellow:
                {
                    ReadInputClick((int)ColorOfButton.yellow);
                    print(currentPassword);
                    print("yellow");
                }
                break;
            case ColorOfButton.green:
                {
                    ReadInputClick((int)ColorOfButton.green);
                    print(currentPassword);
                    print("green");
                }
                break;
            case ColorOfButton.blue:
                {
                    ReadInputClick((int)ColorOfButton.blue);
                    print(currentPassword);
                    print("blue");
                }
                break;
            case ColorOfButton.orange:
                {
                    ReadInputClick((int)ColorOfButton.orange);
                    print(currentPassword);
                    print("orange");
                }
                break;
            case ColorOfButton.purple:
                {
                    ReadInputClick((int)ColorOfButton.purple);
                    print(currentPassword);
                    print("purple");
                }
                break;
        }
        CheckPassword();
    }

    private void CheckPassword()
    {
        if (currentPassword.Length < 4)
            return;

        if(currentPassword.Equals(password))
        {
            print("correct!");
        }
    }

    private void ReadInputClick(int number)
    {
        currentPassword.Append(number);
        currentPassword.Remove(0, 1);  // remove first number to save 4-signs password
    }
}