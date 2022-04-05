using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] GameObject winScreen,onGameScreen,tButton, rButton, preGameScreen;
    bool preGame;
  
      
    
    void Awake()
    {
        instance = this;
    
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!preGame)
            {
                preGameScreen.SetActive(false);
                onGameScreen.SetActive(true);
                preGame = true;
            }
        }
    }
    public void CallWinScreen()
    {
        winScreen.SetActive(true);
    } 
    public void CloseGame()
    {
        print("Quiting");
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    public void Retry()
    {
        tButton.SetActive(false);
        rButton.SetActive(true);
    }
    public void GameScreenOff()
    {
        onGameScreen.SetActive(false);
    }
   
    
}

