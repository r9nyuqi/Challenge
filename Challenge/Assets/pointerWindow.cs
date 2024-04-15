using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pointerWindow : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPosition;
    private RectTransform pointerRecTransform;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.position;
        pointerRecTransform = transform.Find("pointer").GetComponent<RectTransform>();

    }

    
    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
    }

   
}
