using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{   
    public CollectorOfArrows Collector;
    public void FixedUpdate()
    {
        transform.position += transform.up.normalized * 450 * Time.deltaTime;
        if(transform.localPosition.y > 950)
        {   
            Collector.Die();
            Destroy(this.gameObject);
        }
    }
}
