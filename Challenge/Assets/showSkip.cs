using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class showSkip : MonoBehaviour
{

    public Text text;
    public String display;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            display = "Skipping tutorial...";
            text.text = display.ToString();
        }
    }
}
