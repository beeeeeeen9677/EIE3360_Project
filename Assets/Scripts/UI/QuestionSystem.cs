using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSystem : MonoBehaviour
{
    public GameObject UI;
    public UIQuestion questionObject;
    public UIButton buttonObjA;
    public UIButton buttonObjB;
    public UIButton buttonObjC;
    public UIButton buttonObjD;


    public static QuestionSystem instance;
    public int currentQuestionZone;
    public string playerAnswer;
    public string correctAnswer;


    private List<string> Q0 = new List<string>() { "Year of Battle of Dunkirk", "1938", "1939", "1940", "1941","C"};
    private List<string> Q1 = new List<string>() { "Sample Question 1", "Sample Answer A1", "Sample Answer B1", "Sample Answer C1", "Sample Answer D1", "B"};
    private List<string> Q2 = new List<string>() { "Sample Question 2", "Sample Answer A2", "Sample Answer B2", "Sample Answer C2", "Sample Answer D2", "D"};

    private List<List<string>> questionList = new List<List<string>>();
    



    private void Awake()
    {
        instance = this;
        questionList.Add(Q0);
        questionList.Add(Q1);
        questionList.Add(Q2);
        UI = GameObject.Find("UI");
        UI.SetActive(false);
    }

    public void GetAnswer(string ansChar) 
    {
        playerAnswer = ansChar;
        if(ansChar == correctAnswer)
        {
            Debug.Log("Correct");
            DoorManager.instance.AnswerCorrect(currentQuestionZone);
            UI.SetActive(false);
        }
        else 
        {
            Debug.Log("Wrong");
            DoorManager.instance.AnswerWrong(currentQuestionZone);
        }
    }

    


    public void InitQuestion() 
    {
        questionObject.SetQuestion(questionList[currentQuestionZone][0]);
        buttonObjA.SetAnswer(questionList[currentQuestionZone][1]);
        buttonObjB.SetAnswer(questionList[currentQuestionZone][2]);
        buttonObjC.SetAnswer(questionList[currentQuestionZone][3]);
        buttonObjD.SetAnswer(questionList[currentQuestionZone][4]);

        correctAnswer = questionList[currentQuestionZone][5];
    }
}
