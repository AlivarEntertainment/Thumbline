using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Joystick;
public class FightController : MonoBehaviour
{
    public DynamicJoystick Joystick;
    public Vector3 moveInput;
    public float moveSpeed;
    public Rigidbody2D rb;
     private bool facingRight = true;
     public Animator anim;
    public void Update()
    {
        moveInput.x = Joystick.Horizontal; // Get horizontal input (A/D or Left/Right Arrow)
        moveInput.y = Joystick.Vertical;
        moveInput.Normalize();
        if(moveInput.magnitude >= 0.1)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
    private void Flip()
    {
        facingRight = !facingRight; // Toggle the facing direction
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1; // Invert the X scale
        transform.localScale = currentScale;
    }
}
