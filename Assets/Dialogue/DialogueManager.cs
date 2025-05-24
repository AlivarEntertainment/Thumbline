using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Animator boxAnim;
    public Animator startAnim;
    int CurrentSent = 0;
    public PlayableDirector SecondCutScene;
    public PlayableDirector ThirdCutScene;
    private Queue<string> sentences;
    public bool SecondDial;
    public bool JabiDial;
    public bool IsLasto4ka;
    public int Seconds;
    public GameObject ButtonStart;
    [Header("Speaker")]
    public string[] SpeakerName;
    public int CurName = 0;
    public TextMeshProUGUI StartSpeekText;
    public void Start()
    {   
        nameText.text = SpeakerName[CurName];
        sentences = new Queue<string>();
       // startAnim.SetBool("Veiw", true);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        //nameText.text = dialogue.name;
        if(SecondDial == false)
        {
            sentences.Clear();
            foreach(string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            //nameText.text = dialogue.name;
        }
        
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {   
        CurrentSent++;
        CurName++;
        nameText.text = SpeakerName[CurName];
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if(CurrentSent == 5 && IsLasto4ka == true)
        {   
            
            SecondCutScene.Play();
            EndDialogue();
        }
        if(CurrentSent == 7 && JabiDial == false && IsLasto4ka == false)
        {   
            CurrentSent += 2;
            
            StartSpeekText.text = "Поговорить с Ласточкой";
            //nameText.text = "Ласточка Ольга";
            SecondDial = true;
            startAnim.SetBool("startOpen", false);
            SecondCutScene.Play();
            EndDialogue();
            
        }
        if(CurrentSent == 6 && JabiDial == true)
        {
            
            ButtonStart.SetActive(false);
            StartCoroutine(ChangeAfterCutScene());
            Debug.Log("54646");
            SecondCutScene.Play();
            EndDialogue();
        }
        if(CurrentSent == 15)
        { 
            ThirdCutScene.Play();
            EndDialogue();
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        boxAnim.SetBool("boxOpen", false);
    }
    IEnumerator ChangeAfterCutScene()
    {   
        Debug.Log("3223");
        yield return new WaitForSeconds(14);
        SceneManager.LoadScene(3);
    }
}
