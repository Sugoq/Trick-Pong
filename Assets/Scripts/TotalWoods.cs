using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalWoods : MonoBehaviour
{
    public static TotalWoods instance;
    public List<GameObject> woodsToHit = new List<GameObject>();

    private void Awake()
    {
        instance = this;
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
