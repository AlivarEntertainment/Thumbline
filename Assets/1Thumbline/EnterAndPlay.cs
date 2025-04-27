using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnterAndPlay : MonoBehaviour
{   
    public PlayableDirector StartCutScene;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCutScene.Play();
        }
    }
}
