using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FishController : MonoBehaviour
{   
    [Header("Base")]
    public Animator FishAnim;
    public bool IsRaftStyle;
    [Space]
    [Header("MoveRaft")]
    public Vector3 direction;
    public FixedJoystick joystick;
    public float speed;
    float ver;
    public float turnSpeed;
    [Space]
    [Header("TiltAx")]
    public bool FacingRight;
    public bool NeedToTilt = false;
    public bool TiltCorStart;
    void Start()
    {
        StartCoroutine(ChangeMode());
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(IsRaftStyle == true)
        {
            RaftStyle();
        }
        else if(IsRaftStyle == false)
        {
            BubbleCoinStyle();
            if(TiltCorStart == true)
            {
                StartCoroutine("TiltCor");
            }
            
        }
    }
    
    public void RaftStyle()
    {
        ver = joystick.Horizontal * Time.deltaTime * speed;
        transform.Translate(direction * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, ver));
        //Vector3 currentRotation = transform.localEulerAngles;
        if(joystick.Horizontal < 0)
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
        if(joystick.Horizontal > 0)
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }
        if(joystick.Horizontal > 0.5f)
        {
            FishAnim.SetBool("MoveR", true);
        }
         if(joystick.Horizontal < -0.5f)
        {
            FishAnim.SetBool("MoveL", true);
        }
        else if(joystick.Horizontal > -0.5f && joystick.Horizontal < 0.5f)
        {
            FishAnim.SetBool("MoveR", false);
            FishAnim.SetBool("MoveL", false);
        }
    }
    public void BubbleCoinStyle()
    {
        Vector3 acceleration = Input.acceleration;
        
        if(NeedToTilt == true)
        {
            if(FacingRight == true)
            {
                if(acceleration.y > 1f)
                {
                    NeedToTilt = false;
                }
            }
            else
            {
                if(acceleration.y < 1f)
                {
                    NeedToTilt = false;
                }
            }
        }
    }
    IEnumerator TiltCor()
    {   
        TiltCorStart = false;
        for(int i = 0; i <= 6; i++)
        {
            yield return new WaitForSeconds(6f);
            Flip();
            FishAnim.SetTrigger("Tilt");
            NeedToTilt = true;
            StartCoroutine(DieNotTilting());
        }
    }
    IEnumerator DieNotTilting()
    {
        yield return new WaitForSeconds(4f);
        if(NeedToTilt == true)
        {
            SceneManager.LoadScene(4);
        }
    }
    IEnumerator ChangeMode()
    {
        for(int z = 0; z <= 4; z++)
        {   
            yield return new WaitForSeconds(15f);
            IsRaftStyle = !IsRaftStyle;
            TiltCorStart = true;
        }
    }
    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Boloto")
        {
            SceneManager.LoadScene(4);
        }
    }
}
