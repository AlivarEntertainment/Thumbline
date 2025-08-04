using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PushButtons : MonoBehaviour
{
    public Animator DanceAnim;
    public void OnLeftButClick(CollectorOfArrows collector)
    {   
        collector.Push();
        if(collector.IsGood == true)
        {
            DanceAnim.SetTrigger("Left");
        }
        else
        {
            DanceAnim.SetTrigger("Fail");
        }
        
    }
    public void OnDownButClick(CollectorOfArrows collector)
    {
        collector.Push();
        if(collector.IsGood== true)
        {
            DanceAnim.SetTrigger("Down");
        }
        else
        {
            DanceAnim.SetTrigger("Fail");
        }
    }
    public void OnUpButClick(CollectorOfArrows collector)
    {
        collector.Push();
        if(collector.IsGood == true)
        {
            DanceAnim.SetTrigger("Up");
        }
        else
        {
            DanceAnim.SetTrigger("Fail");
        }
    }
    public void OnRightButClick(CollectorOfArrows collector)
    {
        collector.Push();
        if(collector.IsGood == true)
        {
            DanceAnim.SetTrigger("Right");
        }
        else
        {
            DanceAnim.SetTrigger("Fail");
        }
    }
}
