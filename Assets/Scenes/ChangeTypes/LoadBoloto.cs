using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadBoloto : MonoBehaviour
{   
    public int SceneToOpen;
    public void OnSkipButtobClick()
    {
        SceneManager.LoadScene(SceneToOpen);
    }
}
