using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{   
    public CollectorOfArrows Collector;
    public float Speed = 450;
    public void FixedUpdate()
    {
        transform.position += transform.up.normalized * Speed * Time.deltaTime;
        if(transform.localPosition.y > 950)
        {   
            Collector.Die();
            Destroy(this.gameObject);
        }
    }
}
