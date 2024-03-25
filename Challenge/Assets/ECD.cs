using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECD : MonoBehaviour
{
    // Start is called before the first frame update
    public float Timer = 0;
    public String Display;
    bool isE = false;
    bool loadE = true;

    public Text EText;


    // Update is called once per frame
    void Update()
    {

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E) && !isE && Timer <= 0 && loadE)
        {
            isE = true;

            Timer = (float)(3);
            loadE = false;
        }
        else
        {
            isE = false;

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            loadE = true;
        }

        Display = updateTimer(Timer);
        EText.text = Display.ToString();

    }

    String updateTimer(float time)
    {


        if (time <= 0) return "0";


        else return time.ToString("F1");
    }
}
