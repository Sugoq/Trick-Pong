using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    public static StarController instance;
    public float attempts,woodsHit;
    [SerializeField] GameObject secondStar, thirdStar;
    [SerializeField] Image sStar;
    
    
    
    private void Awake()
    {
       
        instance = this;
    }
    public void WoodsHitCount()
    {
        woodsHit++;
        
    }
    public void UiStars()
    {
        attempts = PlayerPrefs.GetInt("attempts");
        sStar.fillAmount = woodsHit / TotalWoods.instance.woodsToHit.Count;
        if (attempts <= 10) thirdStar.SetActive(true);
        //print("oi");
        PlayerPrefs.SetInt("attempts", 0);
        StarControl.instance.SetStarText();
        
    }
  
}
