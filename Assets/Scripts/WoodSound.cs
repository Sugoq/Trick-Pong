using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSound : MonoBehaviour
{
    public static WoodSound instance;
    public float vol = 0.1f;
    [SerializeField] GameObject wood;
    bool hit;



    private void Awake()
    {
        instance = this;
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioController.instance.PlayOnWoodSound(vol);
        if(!hit)StartCoroutine(ChangeColorRoutine());
        StarController.instance.WoodsHitCount();
    }
    IEnumerator ChangeColorRoutine()
    {


        hit = true;       
        Material woodMaterial = wood.GetComponent<MeshRenderer>().material;
        for (float t = 0; t < 1; t += Time.deltaTime *4)
        {
            woodMaterial.SetFloat("_Hit", t);
            yield return null;
        }
        

    }

        void Update()
    {
        
    }
}
