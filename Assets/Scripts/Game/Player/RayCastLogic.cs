using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RayCastLogic : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private CinemachineVirtualCamera playerCamera2;
    [SerializeField] private float distanceRay;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Canvas canvasHit;
    private Ray ray;
    private bool isRayOn;
    private RaycastHit hit;
    private int[] x = new int[4];

    private void Start()
    {
        isRayOn = true;
    }
    private void Update()
    {
        if (isRayOn)
        {
            MyRay();
            DrawRay();
        }
    }
    private void MyRay()
    {
        ray = playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(ray, out hit, distanceRay, layerMask))
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.transform.TryGetComponent(out IInteractable item))
                {
                    item.Interact();
                }
            }
            canvasHit.enabled = true;
            Debug.DrawRay(ray.origin, ray.direction * distanceRay, Color.blue);
        }

        if (hit.transform == null)
        {
            canvasHit.enabled = false;
            Debug.DrawRay(ray.origin, ray.direction * distanceRay, Color.red);
        }
    }
    public void RayOn()
    {
        isRayOn = true;
    }

    public void RayOff()
    {
        isRayOn = false;
    }
}
