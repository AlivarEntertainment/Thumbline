using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
//using Joystick;
public class FightController : MonoBehaviour
{
    public DynamicJoystick Joystick;
    public Vector3 moveInput;
    public float moveSpeed;
    public Rigidbody2D rb;
    private bool facingRight = true;
    public Animator anim;
    [Header("Damage")]
    public int HP_Count;
    public Image[] Heart;
    public Color DieColor;
    public bool IsDamaged;

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
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Muhomor")
        {   
            if(HP_Count > 1 && IsDamaged == false)
            {   
                anim.SetTrigger("Damage");
                IsDamaged = true;
                StartCoroutine(DamageCoolDown());
                HP_Count--;
                Heart[HP_Count].color = DieColor;
            }
            else if(HP_Count == 1 && IsDamaged == false)
            {
                anim.SetTrigger("Die");
                IsDamaged = true;
                StartCoroutine(DamageCoolDown());
                HP_Count--;
                Heart[HP_Count].color = DieColor;
                StartCoroutine(DyeCoroutine());
            }
        }
    }
    IEnumerator DyeCoroutine()
    {   
        moveSpeed = 0;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(12);
    }
    IEnumerator DamageCoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        IsDamaged = false;
    }
}
