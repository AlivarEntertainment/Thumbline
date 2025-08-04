using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpSpeed;
    public Animator DuimAnimator;
    public void OnJumpButtonClick()
    {
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        DuimAnimator.SetTrigger("Jump");
    }
    public void OnSlideButtonClick()
    {
        DuimAnimator.SetTrigger("Slide");
    }
}
