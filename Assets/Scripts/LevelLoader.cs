using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] List<GameObject> levels = new List<GameObject>();
    
    [SerializeField] int forceLevel;
    [SerializeReference] bool force;
    

    public static LevelLoader instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;     
    }
    public void LevelLoad()
    {
        int levelToLoad = PlayerPrefs.GetInt("level", 0);
        if (!force) Instantiate(levels[levelToLoad], transform.position, Quaternion.identity);
        else Instantiate(levels[forceLevel], transform.position, Quaternion.identity);
    }
    public void WinLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("level", 0);
        currentLevel = (currentLevel + 1) % levels.Count;
        PlayerPrefs.SetInt("level", currentLevel);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
   
    public void ResetLevel()
    {
        int reloadLevel = PlayerPrefs.GetInt("level", 0);
        reloadLevel = (reloadLevel - 1 <0? levels.Count-1: reloadLevel -1);
        PlayerPrefs.SetInt("level", reloadLevel);
        ReloadScene();
    }
    void Start()
    {
        LevelLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
