using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject[] DefaultChuncks;
    public GameObject[] EmptyChuncks;
    private Chucnk CurrentChunck;
    public float Interval;
    public GameObject[] ChuncksArray;
    public bool SpawnEmpty;
    private int CycleValue;
    public GameObject FinalChunck;
    public void Start()
    {
        StartCoroutine(RemakeLevel());
    }
    public void FixedUpdate()
    {
        if(CycleValue == 13)
        {
            CurrentChunck = ChuncksArray[ChuncksArray.Length - 1].gameObject.GetComponent<Chucnk>();
            GameObject NewChuck = Instantiate(FinalChunck, CurrentChunck.SpawnNext.position, Quaternion.identity);
            this.enabled = false;
        }
    }
    IEnumerator RemakeLevel()
    {   
        for(int i = 0; i <= 12; i++)
        {   
            
            yield return new WaitForSeconds(Interval);
            if(SpawnEmpty == false)
            {
                Destroy(ChuncksArray[0].gameObject);
                CurrentChunck = ChuncksArray[ChuncksArray.Length - 1].gameObject.GetComponent<Chucnk>();
                GameObject NewChuck = Instantiate(DefaultChuncks[Random.Range(0, DefaultChuncks.Length -1)], CurrentChunck.SpawnNext.position, Quaternion.identity);
                //Chucnk SecondChuck = NewChuck.GetComponent<Chucnk>();
                //GameObject EmtyChuk = Instantiate(EmptyChuncks[Random.Range(0, EmptyChuncks.Length -1)], SecondChuck.SpawnNext.position, Quaternion.identity);
                List<GameObject> NewChuckList = new List<GameObject>();
                NewChuckList.Add(ChuncksArray[ChuncksArray.Length - 2]);
                NewChuckList.Add(ChuncksArray[ChuncksArray.Length - 1]);
                NewChuckList.Add(NewChuck);
                SpawnEmpty = !SpawnEmpty;
                //NewChuckList.Add(EmtyChuk);
                //ChuncksArray.Length = 0;
                ChuncksArray = NewChuckList.ToArray();
            }
            else
            {
                Destroy(ChuncksArray[0].gameObject);
                CurrentChunck = ChuncksArray[ChuncksArray.Length - 1].gameObject.GetComponent<Chucnk>();
                //GameObject NewChuck = Instantiate(DefaultChuncks[Random.Range(0, DefaultChuncks.Length -1)], CurrentChunck.SpawnNext.position, Quaternion.identity);
                //Chucnk SecondChuck = NewChuck.GetComponent<Chucnk>();
                GameObject EmtyChuk = Instantiate(EmptyChuncks[Random.Range(0, EmptyChuncks.Length -1)], CurrentChunck.SpawnNext.position, Quaternion.identity);
                List<GameObject> NewChuckList = new List<GameObject>();
                NewChuckList.Add(ChuncksArray[ChuncksArray.Length - 2]);
                NewChuckList.Add(ChuncksArray[ChuncksArray.Length - 1]);
                NewChuckList.Add(EmtyChuk);
                SpawnEmpty = !SpawnEmpty;
                //NewChuckList.Add(EmtyChuk);
                //ChuncksArray.Length = 0;
                ChuncksArray = NewChuckList.ToArray();
            }
            CycleValue++;
        }
        
    }
}
