using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChaseController : MonoBehaviour
{   
    bool IsMoving;
    public Animator ThumbAnimator;
     public Vector2 target;
     public bool FacingRight;
     public void FixedUpdate()
     {  
        var step =  3 * Time.deltaTime;
        if(IsMoving == true)
        {   
           
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position.x == target.x && transform.position.y == target.y)
            {
                IsMoving = false;
            }
        }
     }
    public void OnRightButtonClick()
    {
        if(transform.position.x <= 0f && IsMoving == false)
        {   
            if(FacingRight == false)
            {
                Flip();
            }
            ThumbAnimator.SetTrigger("JumpSide");
            target = new Vector2(transform.position.x + 1.5f, transform.position.y);
            IsMoving = true;
        }
    }
    public void OnLeftButtonClick()
    {
        if(transform.position.x >= 0f && IsMoving == false)
        {   
            if(FacingRight == true)
            {
                Flip();
            }
            ThumbAnimator.SetTrigger("JumpSide");
            target = new Vector2(transform.position.x - 1.5f, transform.position.y);
            IsMoving = true;
        }
    }
    public void OnForwardButtonClick()
    {   
        if(IsMoving == false)
        {
            ThumbAnimator.SetTrigger("UpJump");
        IsMoving = true;
        target = new Vector2(transform.position.x, transform.position.y + 1);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boloto")
        {
            SceneManager.LoadScene(3);
        }
    }
    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
