using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FCD : MonoBehaviour
{
    // Start is called before the first frame update
    public float Timer = 0;
    public String Display;
    bool isQ = false;
    bool loadQ = true;

    public Text QText;


    // Update is called once per frame
    void Update()
    {

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F) && !isQ && Timer <= 0 && loadQ)
        {
            isQ = true;

            Timer = (float)(5);
            loadQ = false;
        }
        else
        {
            isQ = false;

        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            loadQ = true;
        }

        Display = updateTimer(Timer);
        QText.text = Display.ToString();

    }

    String updateTimer(float time)
    {


        if (time <= 0) return "0";


        else return time.ToString("F1");
    }
}
