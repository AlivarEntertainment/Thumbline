using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public PlayerController playerController;

    public Vector2 TransformClose;
    public Transform transformTr;

    public Vector2 PlayerCurVector;
    public void Start()
    {
        TransformClose = new Vector2(transformTr.position.x, transformTr.position.y);
    }
    public void Update()
    {
        if(playerController.gameObject.transform.position.x == TransformClose.x && playerController.gameObject.transform.position.y == TransformClose.y)
        {
            playerController.CanMove = true;
            playerController.touchEndPos = PlayerCurVector;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerCurVector = playerController.touchEndPos;
            playerController.touchEndPos = TransformClose;
    
        }
    }
}
