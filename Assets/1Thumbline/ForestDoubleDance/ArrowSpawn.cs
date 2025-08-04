using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Transform[] ArrowSpawns;
    public GameObject[] Arrows;
    public CollectorOfArrows[] Collectors;
    public Transform ArrowParent;
    //public Arrow SpawnedArrow;
    //public Transform[] BestPos;

    public void Start()
    {
        StartCoroutine(spawnArrow());
    }
    public IEnumerator spawnArrow()
    {
        for(int i = 0; i < 30; i++)
        {   
            yield return new WaitForSeconds(2);
            int CurrentRandom = Random.Range(0, 4);
            Debug.Log(CurrentRandom);
            GameObject Spawned = Instantiate(Arrows[CurrentRandom], ArrowSpawns[CurrentRandom].position, Quaternion.identity, ArrowParent);
            Collectors[CurrentRandom].ArrowList.Add(Spawned.gameObject); 
            Spawned.GetComponent<Arrow>().Collector = Collectors[CurrentRandom];
        }
    }
}
