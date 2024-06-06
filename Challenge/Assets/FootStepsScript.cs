using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsScript : MonoBehaviour
{
    public GameObject footstep;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            FootSteps();
        }
        else
        {
            StopFootSteps();
        }
    }

    void FootSteps()
    {
        if (!footstep.activeSelf) // Only set active if it's not already active
        {
            footstep.SetActive(true);
        }
    }

    void StopFootSteps()
    {
        if (footstep.activeSelf) // Only set inactive if it's currently active
        {
            footstep.SetActive(false);
        }
    }
}