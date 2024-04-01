using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float remainTime;
    [SerializeField]
    private Animator HP_Effect;
    [SerializeField]
    private TextMeshProUGUI effectText;
    private Animator anim;
    [SerializeField]
    public bool cleared { get; private set; } = false;
    public bool failed { get; private set; } = false;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        remainTime = 100;
    }

    public float getTime() {
        return this.remainTime;
    }

    void FixedUpdate()
    {
        if (cleared) 
            return;    

        remainTime -= Time.fixedDeltaTime;

        if (remainTime <= 0)
        {
            remainTime = 0;
            if(!failed)
            {
                failed = true;
                CityGM.instance.LevelFailed();
            }
        }
        timerText.text = remainTime.ToString("00.00") + " S";

    }

    public void ChangeTime(float amount) 
    {
        string triggerStr = amount > 0 ? "Green" : "Red";
        effectText.text = amount > 0 ? "+" + amount : amount.ToString();

        HP_Effect.SetTrigger(triggerStr);
        anim.SetTrigger(triggerStr);
        remainTime += amount;
    }
    public void LevelClear() 
    {
        cleared = true;
    }
}
