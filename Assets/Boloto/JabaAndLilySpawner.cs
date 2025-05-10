using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JabaAndLilySpawner : MonoBehaviour
{
    /*public GameObject JabaObj;
    //public Transform JabaPos;
    public GameObject LiliysSpawnerObj;
   // public Transform LilyPos;*/
    public GameObject[] FoundJabas;
    public GameObject[] FoundLiliyes;

    void Start()
    {
        int CurScene = SceneManager.GetActiveScene().buildIndex;
        FoundJabas = GameObject.FindGameObjectsWithTag("Jaba");
        FoundLiliyes = GameObject.FindGameObjectsWithTag("LilyS");
        if(FoundJabas.Length >= 1 && FoundLiliyes.Length >= 1 && FoundJabas[FoundJabas.Length -1 ] != null && FoundLiliyes[FoundLiliyes.Length -1 ] != null) 
        {
            /*JabaObj = Instantiate(JabaObj, JabaPos);
            LiliysSpawnerObj = Instantiate(LiliysSpawnerObj, LilyPos);*/
            DontDestroyOnLoad(FoundJabas[FoundJabas.Length - 1]);
            DontDestroyOnLoad(FoundLiliyes[FoundLiliyes.Length - 1]);
        }
        if(FoundJabas.Length >= 2 && FoundLiliyes.Length >= 2)
        {
            Destroy(FoundJabas[FoundJabas.Length - 2]);
           // FoundJabas.Clear(FoundJabas, FoundJabas[0]);
            Destroy(FoundLiliyes[FoundLiliyes.Length - 2]);
        }
        if(CurScene == 5)
        {
            for(int i = 0; i <= FoundLiliyes.Length; i++)
            {
                Destroy(FoundJabas[i]);
                Destroy(FoundLiliyes[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
