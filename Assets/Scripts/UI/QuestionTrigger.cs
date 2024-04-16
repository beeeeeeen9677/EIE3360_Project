using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public int currentQuestionZone;
    public GameObject QuestionUI;

    private void Awake()
    {
        //QuestionUI = GameObject.Find("UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            QuestionUI.SetActive(true);
            QuestionSystem.instance.currentQuestionZone = this.currentQuestionZone;
            QuestionSystem.instance.InitQuestion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            QuestionUI.SetActive(false);

    }
}
