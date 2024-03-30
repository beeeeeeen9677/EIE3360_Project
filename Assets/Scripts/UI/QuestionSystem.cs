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
    private List<UIButton> buttons = new List<UIButton>();


    public static QuestionSystem instance;
    public int currentQuestionZone;
    public string playerAnswer;
    public string correctAnswer;


    private List<string> Q0 = new List<string>() { "Year of Battle of Dunkirk", "1938", "1939", "1940", "1941","C"};
    private List<string> Q1 = new List<string>() { "Sample Question 1", "Sample Answer A1", "Sample Answer B1", "Sample Answer C1", "Sample Answer D1", "B"};
    private List<string> Q2 = new List<string>() { "Sample Question 2", "Sample Answer A2", "Sample Answer B2", "Sample Answer C2", "Sample Answer D2", "D"};
    private List<string> Q3 = new List<string>() { "Sample Question 2", "Sample Answer A2", "Sample Answer B2", "Sample Answer C2", "Sample Answer D2", "D" };


    private List<List<string>> questionList = new List<List<string>>();
    



    private void Awake()
    {
        instance = this;
        questionList.Add(Q0);
        questionList.Add(Q1);
        questionList.Add(Q2);
        questionList.Add(Q3);


        buttons.Add(buttonObjA);
        buttons.Add(buttonObjB);
        buttons.Add(buttonObjC);
        buttons.Add(buttonObjD);

        UI = GameObject.Find("UI");
        UI.SetActive(false);

        
    }

    

    public void GetAnswer(UIButton button) 
    {
        string ansChar = button.answerChar;
        playerAnswer = ansChar;
        if(ansChar == correctAnswer)//correct
        {
            Debug.Log("Correct");
            DoorManager.instance.AnswerCorrect(currentQuestionZone);
            UI.transform.Find("Answer").gameObject.SetActive(false);
            StartCoroutine(AnswerCorrect(button));
            Timer.instance.ChangeTime(10);
            //UI.SetActive(false);
        }
        else //wrong
        {
            Debug.Log("Wrong");
            DoorManager.instance.AnswerWrong(currentQuestionZone);
            button.WrongAns();
            Timer.instance.ChangeTime(-5);

        }
    }

    IEnumerator AnswerCorrect(UIButton b)
    {
        ResetAllButtons();
        questionObject.SetQuestion("Answer: "+b.answerChar+". "+b.answerText);
        //questionObject.GreenBgColor();
        yield return new WaitForSeconds(2);
        //questionObject.ResetBgColor();
        UI.SetActive(false);
        UI.transform.Find("Answer").gameObject.SetActive(true);
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


    public void ResetAllButtons() 
    {
        foreach (UIButton button in buttons)
        {
            //button.gameObject.SetActive(status);
            button.ResetButton();
        }
    }

    

}
