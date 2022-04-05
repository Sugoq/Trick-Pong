using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SecondInputC : MonoBehaviour
{
    // Start is called before the first frame update
    public static SecondInputC instance;
    static Vector3 shootDirection;
    public Vector3 direction;
    Vector3 pivo;
    int UILayer;
    bool blockInput;
    bool shoot;
    public float yMultiplier;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");

    }
    void Update()
    {


        if (Input.GetMouseButton(0) && !IsPointerOverUIElement())
        {

            direction.x += Input.GetAxis("Mouse X");
            direction.z += Input.GetAxis("Mouse Y");
            direction.y = new Vector2(direction.x, direction.z).magnitude * yMultiplier;



            
            Ball.instance.DrawProjection(direction);
        }

        else if (Input.GetMouseButtonUp(0) && !IsPointerOverUIElement())
        {

            
            print(direction);
            Ball.instance.DrawProjection(direction);

        }
        else if (Input.GetMouseButton(0) && IsPointerOverUIElement())
        {
            
            Ball.instance.Shoot(direction);

        }
    }
    public void Throw()
    {
        shoot = true;
        /*shootDirection = direction;
        print(direction);
        
        shootDirection.Scale(forceMultiplier);
        Ball.instance.Shoot(shootDirection);
        Projection.instance.HideLine();*/
    }


   

    #region UI Functions 
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        UnityEngine.EventSystems.PointerEventData eventData = new UnityEngine.EventSystems.PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
    #endregion
}

