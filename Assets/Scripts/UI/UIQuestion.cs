using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestion : MonoBehaviour
{
    public TextMeshProUGUI questionText;

    public void SetQuestion(string qText) 
    {
        questionText.text = qText;
    }
}
