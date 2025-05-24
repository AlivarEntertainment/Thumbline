using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Menu : MonoBehaviour
{   
    public PlayableDirector StartCutScene;
    public GameObject AboutPanel;
    public void OnStartButtonClick()
    {
        StartCutScene.Play();
        StartCoroutine("SelfDestroy");
    }
    public void OnAboutClick()
    {
        AboutPanel.SetActive(true);
    }
    public void OnAboutLeave()
    {
         AboutPanel.SetActive(false);
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
