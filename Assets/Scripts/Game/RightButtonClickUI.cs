using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class RightButtonClickUI : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onLeft;
    public UnityEvent onRight;
    public UnityEvent onMiddle;
    public UnityEvent onDoubleLeft;

    private float LastClickTime = 0.0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            float timeFromLastClick = Time.time - LastClickTime;
            LastClickTime = Time.time;
            if (timeFromLastClick < 0.3)
            {
                print("2 click");
                onDoubleLeft.Invoke();
            }
            else
            {
                print("1 click");
                onLeft.Invoke();
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRight.Invoke();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            onMiddle.Invoke();
        }
    }
}
