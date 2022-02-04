using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class WakeUpPanel : MonoBehaviour
{
    [SerializeField] Button first;
    [SerializeField] Button second;
    [SerializeField] Button third;
    [SerializeField] Button fourths;

    
    void Start()
    {
        second.onClick.AddListener(delegate { PrintData("dfdfdf"); });

    }
    void Update()
    {
    }

    public void PrintData(string str)
    {
        print(str);
    }

    private void OnMouseDown()
    {
        print("Click");
    }
}
