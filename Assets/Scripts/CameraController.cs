using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    Vector3 offset;
    public Transform cam;
    Vector3 vel;
    public float smooth;
    public Vector3 midOffset;
    float y;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        y = Ball.instance.transform.position.y;
        offset = cam.position - Ball.instance.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 ball = Ball.instance.transform.position;
        Vector3 pos = ball;
        if (pos.y > y) pos.y = y + (pos.y - y) * 0.7f;
        pos += offset;
        cam.position = Vector3.SmoothDamp(cam.position, pos, ref vel, smooth);
    }
  
    public void AdjustOffset()
    {
        StartCoroutine(AdjustOffsetRoutine());
    }
    IEnumerator AdjustOffsetRoutine()
    {

        Vector3 begin = offset, end = offset + midOffset; 
        for (float t = 0; t<1; t+= Time.deltaTime/2)
        {
            offset = Vector3.Lerp(begin, end, t);  
            yield return null;
        }
    }
}
