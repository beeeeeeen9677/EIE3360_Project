using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthBeach : MonoBehaviour
{
    [SerializeField]
    private int HP = 5;
    [SerializeField]
    private TextMeshProUGUI HP_text;
    [SerializeField]
    private Animator hpEffectAnim;
    [SerializeField]
    private Animator textAnim;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseHP() 
    {
        HP -= 1;
        HP_text.text = "x "+HP.ToString();
        hpEffectAnim.SetTrigger("Red");
        textAnim.SetTrigger("Hurt");
    }
}
