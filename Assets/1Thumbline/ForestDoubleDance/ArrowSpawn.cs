using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public Transform[] ArrowSpawns;
    public GameObject[] Arrows;
    public CollectorOfArrows[] Collectors;
    public Transform ArrowParent;
    public float failCount;
    public Arrow SpawnedArrow;
    public float CullDown;
    public GameObject FinalCutScene;
    //public Transform[] BestPos;

    public void Start()
    {
        StartCoroutine(spawnArrow());
    }
    public IEnumerator spawnArrow()
    {
        for(int i = 0; i < 30; i++)
        {   
            yield return new WaitForSeconds(CullDown);
            int CurrentRandom = Random.Range(0, 4);
            Debug.Log(CurrentRandom);
            GameObject Spawned = Instantiate(Arrows[CurrentRandom], ArrowSpawns[CurrentRandom].position, Quaternion.identity, ArrowParent);
            SpawnedArrow = Spawned.gameObject.GetComponent<Arrow>();
            SpawnedArrow.Speed *= 1 + failCount;
            Collectors[CurrentRandom].ArrowList.Add(Spawned.gameObject); 
            SpawnedArrow.Collector = Collectors[CurrentRandom];
        }
        yield return new WaitForSeconds(10);
        FinalCutScene.SetActive(true);
    }
}
