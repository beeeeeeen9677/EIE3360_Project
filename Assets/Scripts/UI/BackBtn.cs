using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject QuestionUI;

    private void Awake()
    {
        QuestionUI = transform.root.gameObject;
    }
    public void Clicked() 
    {
        QuestionUI.SetActive(false);
    }
}
