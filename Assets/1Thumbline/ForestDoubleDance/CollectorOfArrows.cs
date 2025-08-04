using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorOfArrows : MonoBehaviour
{
    //public GameObject[] ArrowsInZone;
    public bool IsGood;
    public List<GameObject> ArrowList = new List<GameObject>();
    public GameObject ParticleGood;
    int RemoveAble;
    public Animator DanceAnim;
    public GameObject RedLine;
    
    //public GameObject BadParticle;
    public void Push()
    {   
        
        float MinDist = 1000000;
        float Distance = 100000;
        for(int y = 0; y < ArrowList.Count; y++)
        {
            Distance = Vector2.Distance(transform.position, ArrowList[y].transform.position);
            if(Distance < MinDist)
            {
                MinDist = Distance;
                RemoveAble = y;
                Debug.Log(y);
            }
        }
        if(MinDist < 200)
        {
            IsGood = true;
            ParticleGood.SetActive(false);
            ParticleGood.SetActive(true);
            Destroy(ArrowList[RemoveAble].gameObject);
            ArrowList[RemoveAble] = null;
        }
        else
        {   
            Vector2 PosToRed = new Vector2(transform.position.x, transform.position.y + 800);
            RedLine.transform.position = PosToRed;
            RedLine.SetActive(false);
            RedLine.SetActive(true);
            IsGood = false;
            Destroy(ArrowList[RemoveAble].gameObject);
            ArrowList[RemoveAble] = null;
            DanceAnim.SetTrigger("Fail");
        }
        RefreshListTest();
    }
    public void Die()
    {   
         Vector2 PosToRed = new Vector2(transform.position.x, transform.position.y + 800);
        RedLine.transform.position = PosToRed;
        RedLine.SetActive(false);
        RedLine.SetActive(true);
        DanceAnim.SetTrigger("Fail");
        IsGood = false;
        Destroy(ArrowList[0].gameObject);
        ArrowList[0] = null;
        RefreshListTest();
         //BadParticle.SetActive(false);
        //adParticle.SetActive(true);
    }
    public void RefreshListTest()
    {
        List<GameObject> TemporaryList = new List<GameObject>();
        for(int x = 0; x < ArrowList.Count; x++)
        {
            if(ArrowList[x] != null)
            {   
                Debug.Log("Add");
                TemporaryList.Add(ArrowList[x]);
            }
        }
        ArrowList.Clear();
        ArrowList = TemporaryList;
    }
        
    
}
