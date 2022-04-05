using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalogController : MonoBehaviour
{
    public Image image1, image2;
    public RectTransform rt;
    public CanvasScaler scaler;
    float scale;
    void Start()
    {
        image1.enabled = image2.enabled = false;
        scale =  800f/(float)Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !InputController.instance.IsPointerOverUIElement() && !Ball.instance.isShoot)
        {
            image1.enabled = image2.enabled = true;
            rt.anchoredPosition = Input.mousePosition * scale;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            image1.enabled = image2.enabled = false;
        }
    }
}
