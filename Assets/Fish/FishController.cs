using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Vector3 direction;
    public FixedJoystick joystick;
    public float speed;
    float ver;
    public float turnSpeed;
    public Animator FishAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ver = joystick.Horizontal * Time.deltaTime * speed;
        transform.Translate(direction * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, ver));
        Vector3 currentRotation = transform.localEulerAngles;
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
}
