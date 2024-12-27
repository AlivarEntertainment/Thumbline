using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Vector2 touchEndPos;
    public Touch touch;
    public bool CanMove;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    
    public void Start()
    {
        touchEndPos = this.transform.position;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CanMove = true;
        }
        if(CanMove == true)
        {   
            navMeshAgent.destination = touchEndPos;
            //transform.position = Vector2.MoveTowards(this.transform.position, touchEndPos, 0.9f * Time.deltaTime);
            if(this.transform.position.x == touchEndPos.x && this.transform.position.y == touchEndPos.y)
            {
                CanMove = false;
            }
        }
            
    }
    //Detect current clicks on the GameObject (the one with the script attached)
    
}
