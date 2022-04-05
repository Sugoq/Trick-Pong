using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedString : MonoBehaviour
{
    [SerializeField]TMP_Text text;
    [SerializeField] LocalizationKey key;
    [SerializeField] bool star2, star3;
    void Start()
    {
        if (star2) text.text = Localization.instance.GetLocalizedString(key) + StarController.instance.woodsHit;
        else if (star3)
        {
            text.text = Localization.instance.GetLocalizedString(key) + Ball.instance.attempts + "/10";
        }
        else text.text = Localization.instance.GetLocalizedString(key);

    }
    
    
}
