using GLTF.Schema;
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

    private void Awake()
    {
        instance = this;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LevelFailed()
    {
        anim.enabled = true;
    }

    public void RetryLevel()
    {
        // Load the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LevelCleared() 
    {
        gameClearObj.SetActive(true);
        Timer.instance.LevelClear();
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }





}
