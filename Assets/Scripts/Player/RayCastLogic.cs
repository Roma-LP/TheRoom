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
    private Ray ray;
    private bool isRayOn;
    private RaycastHit hit;
    private float currentDistanceRay;
    private int[] x = new int[4];

    private void Start()
    {
        currentDistanceRay = distanceRay;
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
        if (Physics.Raycast(ray, out hit, currentDistanceRay,layerMask))
        {
            currentDistanceRay = hit.distance;
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.transform.TryGetComponent(out IInteractable item))
                {
                    item.Interact();
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.blue);
        }

        if (hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * currentDistanceRay, Color.red);
            currentDistanceRay = distanceRay;
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
