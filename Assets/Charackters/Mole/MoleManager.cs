using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public MoleController[] Moles;
    public GameObject Thumbline;
    public void Start()
    {
        StartCoroutine(MoleCoroutine());
    }
    IEnumerator MoleCoroutine()
    {
        for(int i = 0; i <= 1000; i++)
        {
            for(int y = 0; y < 3; y++)
            {
                yield return new WaitForSeconds(5);
                Debug.Log(y);

                Vector3 direction = (Thumbline.transform.position - Moles[y].gameObject.transform.position).normalized;
                float overshootDistance = 2f; // Например, 0.1f юнита
                Vector3 adjustedTargetPosition = Thumbline.transform.position + direction * overshootDistance;
                Moles[y].ThumblineAttack = new Vector2(adjustedTargetPosition.x, adjustedTargetPosition.y);

                Moles[y].ArrowDirection = direction;
                Moles[y].IsAttacking = true;
                Moles[y].coolingdown = true;
                Moles[y].coolingdownCounter = 0.3f;

                if(y >= 1)
                {   
                    Moles[y-1].Arrow.SetActive(false);
                    Moles[y-1].ThumblineAttack = Vector2.zero;
                    Moles[y-1].IsAttacking = false;
                }
                else if(y < 1 && i > 0)
                {   
                    Moles[Moles.Length -1].Arrow.SetActive(false);
                    Moles[Moles.Length -1].ThumblineAttack = Vector2.zero;
                    Moles[Moles.Length -1].IsAttacking = false;
                }
            }
        }
    }
}
