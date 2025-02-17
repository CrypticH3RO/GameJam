﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    // Got this part from the unity documentation https://docs.unity3d.com/ScriptReference/Input-inputString.html
    public Text gt;

    void Start()
    {
        gt = GetComponent<Text>();
        //gt = "";
    }

    void Update()
    {
        //Debug.Log(gt);
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (gt.text.Length != 0)
                {
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                print("User answered " + gt.text);
                if (gt.text == "snow")
                {
                    print("Correct!");
                }
                else
                {
                    print("Incorrect");
                }
                gt.text = "";
            }
            else
            {
                gt.text += c;
            }
        }
    }
}
