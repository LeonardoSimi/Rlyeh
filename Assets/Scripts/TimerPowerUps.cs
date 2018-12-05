using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPowerUps : MonoBehaviour {

    [SerializeField]
    Image filling;
    public float timeAmt = 15;
    public float time;
    public bool timerOver;
    public RockSpriteChange rockSpriteChange;
    public SwordBehavior swordBehavior;

    // Use this for initialization
    void Start () {

        filling = this.GetComponent<Image>();
        rockSpriteChange = GameObject.Find("Player").GetComponent<RockSpriteChange>();
        swordBehavior = GameObject.Find("Player").GetComponent<SwordBehavior>();
        time = timeAmt;
        timerOver = false;

    }


    // Update is called once per frame
    void Update ()
    { 
        if (time > 0)
        {
            filling.enabled = true;
            timerOver = false;
            time -= Time.deltaTime;
            filling.fillAmount = time / timeAmt;

        }
        else if (time <= 0)
        {
            timerOver = true;
            rockSpriteChange.rockChange = false;
            swordBehavior.Sword.SetActive(false);
            filling.enabled = false;
            this.enabled = false;
        }
    }

    /*public void TimerStart()
    {
        filling.enabled = true;

        if (time > 0)
        {
            timerOver = false;
            time -= Time.deltaTime;
            filling.fillAmount = time / timeAmt;

        }
        else if (time <= 0)
        {
            timerOver = true;
            filling.enabled = false;
        }
    } */
}
