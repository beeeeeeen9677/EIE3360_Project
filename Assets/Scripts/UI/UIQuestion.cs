using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestion : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI questionText;

    public void SetQuestion(string qText) 
    {
        questionText.text = qText;
    }

    public void GreenBgColor() 
    {
        background.color = new Color(93, 255, 113, 119);
    }

    public void ResetBgColor()
    {
        background.color = new Color(255, 255, 255, 119);
    }
}
