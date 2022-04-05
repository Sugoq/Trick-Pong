using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] BoxCollider cl;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            LevelLoader.instance.ReloadScene();
        }    
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
