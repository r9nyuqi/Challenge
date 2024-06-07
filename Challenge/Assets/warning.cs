using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warning : MonoBehaviour
{

    public Image warn;
    public bossHealth bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth.warning)
        {
            warn.color = new Color(225, 225, 225, 50);

        }
        else
        {
            warn.color = new Color(225, 225, 225, 0);
        }
    }
}
