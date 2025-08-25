using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DinoController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator DuimAnimator;
    public bool CanMove = true;
    public Chucnk ChucnkScript;
    [Header("Jump")]
    public float jumpSpeed;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
    }
    public void OnJumpButtonClick()
    {   
        if(!CanMove) return;
        if(isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            DuimAnimator.SetTrigger("Jump");
        }
    }
    public void OnSlideButtonClick()
    {   
        if(!CanMove) return;
        DuimAnimator.SetTrigger("Slide");
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Muhomor")
        {
            CanMove = false;
            ChucnkScript.enabled = true;
            DuimAnimator.SetTrigger("Fail");
            StartCoroutine(ReStartLevel());
        }
    }
    IEnumerator ReStartLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(7);
    }
}
