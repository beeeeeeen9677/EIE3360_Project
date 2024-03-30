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

    private void Awake()
    {
        instance = this;
    }
    public void LevelFailed()
    {
        anim.enabled = true;
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("City");
    }

    public void LevelCleared() 
    {
        gameClearObj.SetActive(true);
        Timer.instance.LevelClear();
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(1);
    }





}
