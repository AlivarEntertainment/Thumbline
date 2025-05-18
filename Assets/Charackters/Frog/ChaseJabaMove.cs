using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseJabaMove : MonoBehaviour
{
    public float Speed;
    public Vector2 targetJump;
    public Transform PlayerPos;
    public Animator JabaChase;
    public GameObject[] Jaba;
   /* public void Awake()
    {
        int CurScene = SceneManager.GetActiveScene().buildIndex;
        Jaba = GameObject.FindGameObjectsWithTag("Jaba");
        if(CurScene == 3 && Jaba.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Jaba.Length >= 2)
        {
            Destroy(Jaba[0].gameObject);
        }
        else if(CurScene == 3 || CurScene == 5)
        {
            Destroy(this.gameObject);
        }
    }*/
    public void OnLevelWasLoaded()
    {
        int CurScene = SceneManager.GetActiveScene().buildIndex;
        if(CurScene == 5)
        {
            Destroy(this.gameObject);
        }
    }
    public void Start()
    {   
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
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
            if(transform.position.y <= 15)
            {
                yield return new WaitForSeconds(6.5f);
            
            if( Vector3.Distance(PlayerPos.position, transform.position) > 10)
            {
                targetJump = new Vector2(transform.position.x, transform.position.y + 10);
                Debug.Log("BigJump");
                JabaChase.SetTrigger("Jump");
            }
            else 
            {   
                JabaChase.SetTrigger("Jump");
                targetJump = new Vector2(transform.position.x, transform.position.y + 5);
            }
            }
            
            
        }
    }
}
