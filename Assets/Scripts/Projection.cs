using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Projection : MonoBehaviour
{
    public static Projection instance;
    [SerializeField] LineRenderer lr;

    [SerializeField]
    [Range(3, 100)]
    private int lineCount = 20;

    private List<Vector3> linePoints = new List<Vector3>();
    public int x;
    public LayerMask mask;




    public void UpdateLine(Vector3 velocity, Rigidbody rb, Vector3 startingPoint)
    {
        if (velocity.magnitude < 0.2f) return;
        var gravity = Physics.gravity * Ball.instance.gravityMultiplier; 
        float flightDuration = (2 * velocity.y) / gravity.y;
        float timeStep = flightDuration / lineCount;
        if (Mathf.Abs(timeStep) < 0.001f) return;
        linePoints.Clear();
        bool hitWood = false;
        for (int i =0; i<lineCount + x; i++)
        {
            float stepTimePassed = timeStep * i;
            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                stepTimePassed * (velocity.y -0.5f * gravity.y*stepTimePassed),
                velocity.z * stepTimePassed
            );
            linePoints.Add(-movementVector+startingPoint);
            if (i > 0)
            {
                RaycastHit hitInfo;
                var dir = linePoints[i] - linePoints[i - 1];
                if (Physics.Raycast(linePoints[i - 1], dir.normalized, out hitInfo, dir.magnitude, mask))
                {
                    hitWood = true;
                    Ball.instance.hitPoint.up = hitInfo.normal;
                    Ball.instance.hitPoint.position = hitInfo.point;
                    linePoints[i] = hitInfo.point;
                    break;
                }
            }
        }
        if(!hitWood) Ball.instance.hitPoint.position =Vector3.up*50;
        float lineLength = 0;
        lr.positionCount = linePoints.Count;
        lr.SetPositions(linePoints.ToArray());
        for(int i = 1; i < linePoints.Count;i++)
        {
           // lineLength += (linePoints[i] - linePoints[i-1]).magnitude;
           lineLength += Vector3.Distance(linePoints[i], linePoints[i-1]); 
        }
        lr.material.SetFloat("_Length", lineLength);
    }
    
    public void HideLine()
    {
        lr.positionCount = 0;
        Ball.instance.hitPoint.localScale = Vector3.zero;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       
    }
    private void Update()
    {
       
    }

}
