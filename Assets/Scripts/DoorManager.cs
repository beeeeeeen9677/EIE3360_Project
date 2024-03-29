using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;
    public GameObject doors0;
    public GameObject triggerZone0;
    public GameObject doors1;
    public GameObject triggerZone1;


    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void AnswerCorrect(int QuestionNumber)
    {
        switch(QuestionNumber) 
        {
            case 0:
                Destroy(triggerZone0);
                doors0.GetComponent<Animator>().SetTrigger("Open");
                break;
            case 1:
                Destroy(triggerZone1);
                doors1.GetComponent<Animator>().enabled = true;
                break;
            default:
                Debug.Log("No such trigger zone");
                break;
        }
    }

    public void AnswerWrong(int QuestionNumber) 
    {
        if (QuestionNumber == 0)
        {

        }
    }
}

