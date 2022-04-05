using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoundsSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        AudioController.instance.PlayOnCupBoundSound();
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
