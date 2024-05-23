using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipInstruction : MonoBehaviour
{
    public Animator animator;

    public bool isskipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Space) && !isskipped)
        {
            print("Skip");
            animator.SetBool("skip", true);
            isskipped = true;
        }
    }
}
