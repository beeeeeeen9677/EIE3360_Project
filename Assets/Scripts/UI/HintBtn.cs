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
    private void FixedUpdate()
    {
        if (CityGM.instance.cleared||CityGM.instance.failed) 
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
