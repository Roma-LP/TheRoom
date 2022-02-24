using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject crossHairObject;

    public void HideCrosshair()
    {
        Cursor.lockState = CursorLockMode.None;
        crossHairObject.SetActive(false);
    }

    public void ShowCrosshair()
    {
        Cursor.lockState = CursorLockMode.Locked;
        crossHairObject.SetActive(true);
    }
}
