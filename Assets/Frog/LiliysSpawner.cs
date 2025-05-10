using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiliysSpawner : MonoBehaviour
{
    public GameObject[] Lily;
    public int AllLiliyes;
    public Vector2 spawnPos;
    float OffsetAdder = 0;
    public void Awake()
    {
        int CurScene = SceneManager.GetActiveScene().buildIndex;
        if(CurScene == 3)
        {   
            for(int i = 0; i <= AllLiliyes; i++)
            {   
            spawnPos = new Vector2(this.transform.position.x, this.transform.position.y + OffsetAdder);
            OffsetAdder += 5f;
            GameObject LilyObj = Instantiate(Lily[Random.Range(0, Lily.Length)], spawnPos, Quaternion.identity);
            LilyObj.transform.SetParent(this.transform);
            }
            
            
        }
       if(CurScene == 5)
        {
            Destroy(this.gameObject);
        }
    }
     public void OnLevelWasLoaded()
    {
        int CurScene = SceneManager.GetActiveScene().buildIndex;
        if(CurScene == 5)
        {
            Destroy(this.gameObject);
        }
    }
    

}
