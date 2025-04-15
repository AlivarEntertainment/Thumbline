using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiliysSpawner : MonoBehaviour
{
    public GameObject[] Lily;
    public int AllLiliyes;
    public Vector2 spawnPos;
    float OffsetAdder = 0;

    public void Start()
    {
        for(int i = 0; i <= AllLiliyes; i++)
        {   
            spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + OffsetAdder);
            OffsetAdder += 5f;
            Instantiate(Lily[Random.Range(0, Lily.Length)], spawnPos, Quaternion.identity);
        }
    }

}
