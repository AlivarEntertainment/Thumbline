using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleController : MonoBehaviour
{
    [Header("Blinding")]
    public float NormalSpeed;
    [SerializeField]private Vector2 RandomPos;
    private bool facingRight = true;
    [Header("Attack")]
    public Vector2 ThumblineAttack;
    public bool IsAttacking;
    public float coolingdownCounter = 0.3f;
    public bool coolingdown = true;
    public float dashSpeed;
    public Animator MoleAnimator;
    [Header("BreakWall")]
    public Slider WallSlider;
    public Sprite[] Walls;
    public SpriteRenderer WallRenderer;
    public BoxCollider2D ColliderWall;
    [Header("Arrow")]
    public GameObject Arrow;
    public Vector3 ArrowDirection;
    public float ArrowRotationSpeed;
    

    public void FixedUpdate()
    {   
        if(IsAttacking)
        {
            DashAttack();
            Quaternion toRotation = Quaternion.LookRotation(ArrowDirection);
            Arrow.transform.rotation = Quaternion.Slerp(Arrow.transform.rotation, toRotation, ArrowRotationSpeed * Time.deltaTime);
        }
        if(!IsAttacking)
        {
            BlindWalking();
        }
        
    }
    public void BlindWalking()
    {   
        MoleAnimator.SetBool("IsWalking", true);
        MoleAnimator.SetBool("IsRunning", false);
        if(transform.position.x == RandomPos.x && transform.position.y == RandomPos.y)
        {
            RandomPos = new Vector2(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-1.0f, 1.0f));
            RandomPos.x = Mathf.Clamp(RandomPos.x, -3, 3);
            RandomPos.y = Mathf.Clamp(RandomPos.y, -4, 4);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, RandomPos, NormalSpeed * Time.deltaTime);
        }
        if(transform.position.x < RandomPos.x && !facingRight)
        {
            Flip();
        }
        if(transform.position.x > RandomPos.x && facingRight)
        {
            Flip();
        }
    }   
    public void DashAttack()
    {   
        MoleAnimator.SetBool("IsWalking", false);
         MoleAnimator.SetBool("IsRunning", true);
        if (!coolingdown) 
        {
            transform.position = Vector2.MoveTowards(transform.position, ThumblineAttack, dashSpeed * Time.deltaTime);
        } 
        else {
            Arrow.SetActive(true);
            Quaternion toRotation = Quaternion.LookRotation(ArrowDirection);
           
            coolingdownCounter -= Time.deltaTime;
            if (coolingdownCounter <= 0) 
            {   
                coolingdown = false;
            }
        }
        if(transform.position.x == ThumblineAttack.x && transform.position.y == ThumblineAttack.y)
        {
            MoleAnimator.SetBool("IsWalking", false);
            MoleAnimator.SetBool("IsRunning", false);
        }
        if(transform.position.x < ThumblineAttack.x && !facingRight)
        {
            Flip();
        }
        if(transform.position.x > ThumblineAttack.x && facingRight)
        {
            Flip();
        }
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
        if(other.gameObject.tag == "Boloto")
        {   
            MoleAnimator.SetTrigger("Stack");
            ThumblineAttack = new Vector2(transform.position.x, transform.position.y);
        }
        if(other.gameObject.tag == "Jaba" && IsAttacking)
        {   
            MoleAnimator.SetTrigger("Stack");
            ThumblineAttack = new Vector2(transform.position.x, transform.position.y);
            if(WallSlider.value == 4)
            {
                WallRenderer.sprite = Walls[0];
            }
            if(WallSlider.value == 2)
            {
                WallRenderer.sprite = Walls[1];
            }
            if(WallSlider.value > 0)
            {
                WallSlider.value--;
            }
            if(WallSlider.value == 0)
            {
                WallRenderer.sprite = Walls[2];
                ColliderWall.enabled = false;
            }
        }
    }
}
