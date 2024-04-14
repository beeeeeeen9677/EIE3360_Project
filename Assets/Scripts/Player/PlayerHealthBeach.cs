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
    [SerializeField]
    private BombManager bm;


    private void Awake()
    {
        HP_text.text = "x " + HP.ToString();
    }


    public void decreaseHP() 
    {
        HP -= 1;
        HP_text.text = "x "+HP.ToString();
        hpEffectAnim.SetTrigger("Red");
        textAnim.SetTrigger("Hurt");

        if (HP <= 0)
        {
            CityGM.instance.LevelFailed();
            Timer.instance.LevelClear();//stop the timer
            bm.StopAttacking();
        }
    }
}
