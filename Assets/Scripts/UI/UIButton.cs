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

    public void Clicked() 
    {
        QuestionSystem.instance.GetAnswer(this);
        
    }

    public void WrongAns() 
    {
        //gameObject.SetActive(false);
        b1.interactable = false;
        b1text.color = new Color(255, 0, 0, 255);
    }

    public void ResetButton()
    {
        b1.interactable = true;
        b1text.color = new Color(0, 0, 0, 255);
    }


    public void SetAnswer(string qText)
    {
        answerText = qText;
        BtnValue();
    }
}
