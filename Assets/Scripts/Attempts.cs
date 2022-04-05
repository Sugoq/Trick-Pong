using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using TMPro;

public class Attempts : MonoBehaviour
{
    public static Attempts instance;

    [SerializeField] TMP_Text attemptsText;

    private void Awake()
    {
        
        instance = this;
    }
    
    

  
}
