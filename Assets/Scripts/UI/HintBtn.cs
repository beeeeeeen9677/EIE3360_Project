using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject hintPanel;
    public void ToggleHint() 
    {
        hintPanel.SetActive(!hintPanel.activeInHierarchy);
    }
}
