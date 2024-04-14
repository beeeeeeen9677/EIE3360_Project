using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private TextMeshProUGUI hint;


    public static QuestionSystem instance;
    public int currentQuestionZone;
    public string playerAnswer;
    public string correctAnswer;


    private List<string> Q0 = new List<string>() { "Battle of Dunkirk took place in which year?", "1938", "1939", "1940", "1941","C", "Find useful hint from here"};

    private List<string> Q1 = new List<string>() { " The success of the Dunkirk retreat \nhad a major impact on which future battle?",
        "the Battle of Stalingrad", 
        "Battle of Britain", 
        "the Normandy landings", 
        "Battle of Moscow", 
        "B", 
        "The success of the Dunkirk evacuation saved a large number of British troops and provided an important defense force for the Battle of Britain. The retreat was important for Britain to maintain its fighting strength in subsequent wars."};

    private List<string> Q2 = new List<string>() { "Which was not a measure taken by \nthe British government to speed up the evacuation?",
        "mobilizing all available ships, including civilian ships",
        "the British government appealed to the public for help through radio broadcasts",
        "deploying the navy and air force for cover and support",
        "requesting additional support from the French army", 
        "D", 
        "In the Dunkirk evacuation, the British government took a number of measures to speed up the evacuation process, including using all available ships, broadcasting appeals for help, and deploying naval and air forces for cover and support. However, the British did not ask for additional support from the French army as they themselves were under attack and pressure from the Germans." };
    
    private List<string> Q3 = new List<string>() { "Which of the following is a correct description \nof the Dunkirk Evacuation?",
        "a large number of soldiers \nwere able to escape during the retreat",
        "was a well-planned military operation",
        "there was no German resistance to the retreat",
        "it was carried out mainly by military ships", 
        "A", 
        "The Dunkirk evacuation was an emergency and large-scale military evacuation in which many soldiers managed to escape. The evacuation was not well planned, it was pursued by the Germans, and a large number of civilian ships were used for the evacuation." };


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

        //UI = GameObject.Find("UI");
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

        hint.text = questionList[currentQuestionZone][6];
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
