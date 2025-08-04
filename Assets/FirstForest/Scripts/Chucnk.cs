using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chucnk : MonoBehaviour
{
   public Transform SpawnNext;
   public Vector3 MoveVector;
   public float Speed;

   public void FixedUpdate()
   {
        transform.position += MoveVector* Speed * Time.deltaTime;
   }
}
