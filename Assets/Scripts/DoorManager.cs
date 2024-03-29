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
    public GameObject doors2;
    public GameObject triggerZone2;
    public GameObject doors3;
    public GameObject triggerZone3;


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
            case 2:
                Destroy(triggerZone2);
                Rigidbody d2rb = doors2.GetComponent<Rigidbody>();
                d2rb.isKinematic = false;
                d2rb.AddForce(new Vector3(-1000, 200, 0), ForceMode.Impulse);
                break;
            case 3:
                Destroy(triggerZone3);
                doors3.GetComponent<Animator>().enabled = true;
                break;
            default:
                Debug.Log("No such trigger zone");
                break;
        }
    }

    public void AnswerWrong(int QuestionNumber) 
    {
        Debug.Log("Wrong");
    }


    /*
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Rigidbody d2rb = doors2.GetComponent<Rigidbody>();
            d2rb.isKinematic = false;
            d2rb.AddForce(new Vector3(-1000, 200, 0), ForceMode.Impulse);
        }
    }
    */
}

