using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    public Vector3 direction;
    int analogLayer,UILayer;
    [SerializeField] RectTransform joystickRt;
    bool dragging;
    Vector2 analogOrigin;
    Vector3 analDir, analPivo;
    public float radius = 50;
    public float speed;
    public float yMultipler;
    public bool onThrow;
    public Vector3 multiplier;
    [SerializeField] float yMax, yMin, xMax;
    

    private void Awake()
    {
        instance = this;
    }  

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
        analogOrigin = joystickRt.anchoredPosition;
        
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIElement() && !Ball.instance.isShoot)
        {
            
            dragging = true;
            analPivo = Input.mousePosition;
            analogOrigin = Input.mousePosition;
            
        }
        

        if(Input.GetMouseButtonUp(0)&& dragging && !IsPointerOverUIElement() && !Ball.instance.isShoot)
        {
            NotDragging();
        }
        if (dragging)
        {
            analDir = Input.mousePosition;
            Vector3 dir =  analPivo - analDir;
            //dir.y = analPivo.y - analDir.y;
            Vector3 aDir = analDir - analPivo;
            /* AnalogControl(aDir);
             dir = new Vector3(dir.x, 2, dir.y);
            var mag = (joystickRt.anchoredPosition - analogOrigin).magnitude / radius; 
            direction += speed*( new Vector3(dir.x, 0, dir.y)/mag)*Time.deltaTime;
            direction.y = new Vector2(direction.x, direction.z).magnitude * yMultipler ;
            if (direction.y >= yMax) direction.y = yMax;
            if (direction.x >= xMax) direction.x = xMax;
            else if (direction.x <= xMax * -1) direction.x = xMax * -1;*/
            direction = new Vector3(dir.x * multiplier.x, dir.y * multiplier.y, dir.y * multiplier.z);

            Ball.instance.DrawProjection(direction);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ball.instance.Shoot(direction);
            Projection.instance.HideLine();
            print(direction);
        }
    }
    
    public void Throw()
    {
        Ball.instance.Shoot(direction);
        Projection.instance.HideLine();
    }
    public void NotDragging()
    {
        joystickRt.anchoredPosition = analogOrigin;
        dragging = false;
    }
    public void AnalogControl(Vector2 dir)
    {
        if (dir.magnitude > radius)
        {
            joystickRt.anchoredPosition = radius * dir.normalized;    
        }
        else
        joystickRt.anchoredPosition = dir;
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

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public void HardReset()
    {
        throw new System.NotImplementedException();
        
    }
    #endregion
}

