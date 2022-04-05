using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    Vector3 splashPosition;
    [SerializeField] GameObject waterSplash, waterTrail;
    public static Water instance;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        splashPosition = other.gameObject.transform.position;
        Destroy(Instantiate(waterSplash, splashPosition, Quaternion.identity),0.3f);
        GameObject g = Instantiate(waterTrail, splashPosition, Quaternion.identity);
        StartCoroutine(ScaleRoutine(g.transform));
        AudioController.instance.PlayWaterSplashSound();
        StartCoroutine(ResetRoutine());
    }
    IEnumerator ScaleRoutine(Transform wt)
    {
        Material parent = wt.gameObject.GetComponent<MeshRenderer>().material;
        Material child = wt.GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        
        Color initialColor = parent.GetColor("_BaseColor");
        Color finalColor = initialColor;
        finalColor.a = 0;
        
        Vector3 initialScale = Vector3.up *0.1f;
        Vector3 finalScale = 3.0f * (Vector3.right + Vector3.forward)+Vector3.up*0.1f;
        for (float t = 0; t < 1; t  += Time.deltaTime)
        {
            wt.localScale = Vector3.Lerp(initialScale, finalScale, 1f-Mathf.Pow(1-t,2));
            parent.SetColor("_BaseColor", Color.Lerp(initialColor, finalColor, t*t));
            child.SetColor("_BaseColor", Color.Lerp(initialColor, finalColor, t*t));
            yield return null;
        }
        wt.localScale = finalScale;
        yield return null;
        Destroy(wt.gameObject);
    }
    public IEnumerator ResetRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        LevelLoader.instance.ReloadScene();
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
