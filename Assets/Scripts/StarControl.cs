using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour
{
    [SerializeField] bool tStar;
    //TMP_Text text;
    public static StarControl instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetStarText()
    {
        if (tStar)
        {
           // text.text = StarController.instance.attempts + "/10";
        }
        
    }
    
    
}
