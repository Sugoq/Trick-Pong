using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColision : MonoBehaviour
{
    [SerializeField] BoxCollider cl;


    public void OnCollisionEnter(Collision collision)
    {
        print("oi");
        if(collision.gameObject.layer == 9)
        {
            Water.instance.ResetRoutine();
            
        }

    }
  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
