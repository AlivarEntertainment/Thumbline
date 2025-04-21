using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseJabaMove : MonoBehaviour
{
    public float Speed;
    public Vector2 targetJump;
    public Transform PlayerPos;
    public Animator JabaChase;
    public void Start()
    {   
        targetJump = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine("MoveDelay");
    }
    public void FixedUpdate()
    {   
        var step =  Speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(this.transform.position, targetJump, step);
    }
    IEnumerator MoveDelay()
    {
        for(int i = 0; i <= 4; i++)
        {   
            
            yield return new WaitForSeconds(6.5f);
            JabaChase.SetTrigger("Jump");
            if( Vector3.Distance(PlayerPos.position, transform.position) > 10)
            {
                targetJump = new Vector2(transform.position.x, transform.position.y + 10);
                Debug.Log("BigJump");
            }
            else
            {
                targetJump = new Vector2(transform.position.x, transform.position.y + 5);
            }
            
        }
    }
}
