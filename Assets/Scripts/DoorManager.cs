using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;
    public GameObject doors0;
    public Animator door0Anim;
    public GameObject triggerZone0;


    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
        door0Anim = doors0.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void AnswerCorrect(int QuestionNumber)
    {
        if (QuestionNumber == 0)
        {
            Destroy(triggerZone0);
            door0Anim.SetTrigger("Open");
        }
    }
}

