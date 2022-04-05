using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target, tf;
    public float offset,offset2;
    Vector3 pos;
   

    // Update is called once per frame
    void Update()
    {
        
        pos = tf.position;
        pos.z = target.position.z +offset;
        pos.x = target.position.x + offset2;
        pos.y = target.position.y * 0.6f;
        tf.position = pos;
    }
}
