using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButton : MonoBehaviour
{
    public Button b1;
    public TextMeshProUGUI b1text;
    public string answerChar;
    public string answerText;


    void Start()
    {
        b1 = GetComponent<Button>();
        //b1text = b1.GetComponentInChildren<TextMeshProUGUI>();
        BtnValue();
    }

    public void BtnValue()
    {
        b1text.text = answerChar+". "+ answerText;
    }

    public void Clicked_A() 
    {
        QuestionSystem.instance.GetAnswer("A");
    }

    public void Clicked_B()
    {
        QuestionSystem.instance.GetAnswer("B");
    }
    public void Clicked_C()
    {
        QuestionSystem.instance.GetAnswer("C");
    }
    public void Clicked_D()
    {
        QuestionSystem.instance.GetAnswer("D");
    }


    public void SetAnswer(string qText)
    {
        answerText = qText;
        BtnValue();
    }
}
