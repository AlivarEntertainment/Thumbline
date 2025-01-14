using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlowerGo : MonoBehaviour
{
    public bool OnFlower;
    public bool CanPress;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            CanPress = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && OnFlower == false)
        {
            CanPress = false;
        }
    }
    public void OnMouseDown()
    {   
        if(OnFlower == false && CanPress == true)
        {
            SceneManager.LoadScene(1);
        }
        else if (OnFlower == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
