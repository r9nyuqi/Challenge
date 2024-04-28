using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public float qTimer = 0;
    public String Display;
    bool isQ = false;
    bool loadQ = true;

    public GameObject rightclick;
    
    public movement movement;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(Input.GetKey(KeyCode.R) && movement.getHasRightClick())
        {
            Instantiate(rightclick, bulletTransform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Mouse0) && !isQ && qTimer <= 0 && loadQ)
        {
            isQ = true;

            qTimer = (float)(0.3);
            loadQ = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);


        }

        else
        {
            isQ = false;


        }
        if (qTimer > 0)
        {
            qTimer -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            loadQ = true;
        }

        Display = updateTimer(qTimer);
    }
    String updateTimer(float time)
    {


        if (time <= 0) return "0";


        else return time.ToString("F1");
    }
}

