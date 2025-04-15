using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Menu : MonoBehaviour
{   
    public PlayableDirector StartCutScene;
    public void OnStartButtonClick()
    {
        StartCutScene.Play();
        Destroy(this.gameObject);
    }
    
}
