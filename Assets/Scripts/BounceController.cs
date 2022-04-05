using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : MonoBehaviour
{
    [SerializeField] float bounceMultiplier = 1;
    float lastHitTime;



    
    private void OnCollisionEnter(Collision collision)
    {
        
            
            if (Time.time - lastHitTime > 0.1f)
            {
                Vector3 reflected = Vector3.Reflect(Ball.instance.velocities.Peek(), collision.contacts[0].normal) * bounceMultiplier;
                Ball.instance.rb.velocity = reflected;
                lastHitTime = Time.time;
            }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
