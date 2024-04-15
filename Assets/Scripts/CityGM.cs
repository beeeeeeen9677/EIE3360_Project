//using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityGM : MonoBehaviour
{
    public static CityGM instance;
    [SerializeField]
    private Animator anim;//gameover
    [SerializeField]
    private GameObject gameClearObj;
    [SerializeField]
    // Get the index of the current scene
    private int currentSceneIndex;
    public bool cleared { get; private set; } = false;
    public bool failed { get; private set; } = false;



    private void Awake()
    {
        instance = this;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LevelFailed()
    {
        anim.enabled = true;
        failed = true;
    }

    public void RetryLevel()
    {
        // Load the current scene
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("Retry");
    }

    public void LevelCleared() 
    {
        gameClearObj.SetActive(true);
        Timer.instance.LevelClear();
        cleared = true;
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
        Debug.Log("Next level");
    }





}
