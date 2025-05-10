using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FishController : MonoBehaviour
{   
    [Header("Base")]
    public Animator FishAnim;
    public bool FacingRight;
    [Space]
    [Header("MoveRaft")]
    public Vector3 direction;
    public FixedJoystick joystick;
    public float speed;
    float ver;
    public float turnSpeed;
    public TextMeshProUGUI SpeedText;
   
    void Start()
    {
       StartCoroutine("AddSpeed");
    }   

    // Update is called once per frame
    void FixedUpdate()
    {   
        RaftStyle();
    }
    
    public void RaftStyle()
    {
       
        transform.Translate(direction * Time.deltaTime);
        //transform.Translate(new Vector3(0, 0, ver));
        //Vector3 currentRotation = transform.localEulerAngles;
        if(ver < 0)
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
        if(ver > 0)
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }
        if(ver > 0.5f)
        {
            FishAnim.SetBool("MoveR", true);
        }
         if(ver < -0.5f)
        {
            FishAnim.SetBool("MoveL", true);
        }
        else if(ver == 0)
        {
            FishAnim.SetBool("MoveR", false);
            FishAnim.SetBool("MoveL", false);
        }
    }
   public void OnRightButtonHold()
   {
        ver = 1;
   }
   public void OnLeftButtonHold()
   {
        ver = -1;
   }
   public void OnPointerUp()
   {
        ver = 0;
   }
    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public IEnumerator AddSpeed()
    {
        for(int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(4);
            direction.y += 2;
            SpeedText.text = direction.y.ToString();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boloto")
        {
            SceneManager.LoadScene(4);
        }
    }
}
