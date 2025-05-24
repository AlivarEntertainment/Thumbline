using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenTap : MonoBehaviour
{
    public int TapTimes;
    public int Tapped;
    public Animator TenAnimator;
    void Start()
    {
        StartCoroutine(TapCoroutine());
    }
    public void OnTaperClick()
    {
        Tapped++;
    }
    IEnumerator TapCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        if(Tapped < TapTimes)
        {   
            TenAnimator.SetTrigger("Ten");
            StartCoroutine("ChangeCor");
        }
    }
    IEnumerator ChangeCor()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("ZAfterFish");
    }
}
