using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 24f;
    public float dashTime = 0.2f; 
    public float dashCoolDown = 3f;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("E") && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x * dashPower, rb.velocity.y * dashPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
