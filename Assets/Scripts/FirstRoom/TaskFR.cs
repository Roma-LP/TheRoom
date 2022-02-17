using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskFR : MonoBehaviour
{
    [SerializeField] private TMP_Text STRcount;
    [SerializeField] private PasswordLetter passwordLetter;

    byte INTcount;
    public void Increment()
    {
        INTcount = byte.Parse(STRcount.text);
        if(INTcount==9)
        {
            STRcount.text = "0";
            INTcount = 0;
        }
        else
        {
            INTcount++;
            STRcount.text = INTcount.ToString();
        }
        DispalyManager.TriggerOnClickPassword(passwordLetter, INTcount);
    }
    public void Decrement()
    {
        INTcount = byte.Parse(STRcount.text);
        if (INTcount == 0)
        {
            STRcount.text = "9";
            INTcount = 9;
        }
        else
        {
            INTcount--;
            STRcount.text = INTcount.ToString();
        }
        DispalyManager.TriggerOnClickPassword(passwordLetter, INTcount);
    }
}
