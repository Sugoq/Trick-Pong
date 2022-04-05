using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreGameController : MonoBehaviour
{
    [SerializeField] TMP_Text ttp, level;
    
    
    void Start()
    {

        level.text = "Level " + PlayerPrefs.GetInt("level").ToString();
        StartCoroutine(TTPInicialRoutine());


    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator TTPInicialRoutine()
    {
        Color iColor = ttp.faceColor;
        Color eColor = iColor;
        eColor.a = 0.1f;
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            ttp.color = Color.Lerp(iColor, eColor, t);
            yield return null;
        }
        StartCoroutine(TTPFinalRoutine());
        yield return null;
    }
    IEnumerator TTPFinalRoutine()
    {
        Color iColor = ttp.faceColor;
        Color eColor = iColor;
        eColor.a = 0.1f;
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            ttp.color = Color.Lerp(eColor, iColor, t);
            yield return null;
        }
        StartCoroutine(TTPInicialRoutine());
        yield return null;

    }
}
