using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ScoreCounter : MonoBehaviour
{
    private int Score;
    int Randomnum;
    private string Score_Text;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void incrementScore()
    {
        Score++;
        Score_Text = "Score: " + Score.ToString();
        gameObject.ConvertTo<TMP_Text>().text = Score_Text;
        //Mod operator returns remainder
        //Checks if point amount eligible for bonus, if so grant it
        if (Score % 5 != 0 ) return;
        BonusGiver();
    }
    void BonusGiver()
    {
        Randomnum = UnityEngine.Random.Range(1,3);
        //Debug.Log(Randomnum);
        if (Randomnum == 1)
        {
            //Debug.Log("healthie");
            HealthScript playerHealthscript = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
            if (!playerHealthscript) return;
            playerHealthscript.UpdateHealth(-1f);
            
        }
        else if (Randomnum == 2)
        {
            //Debug.Log("shottie");
            Weapon playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>();
            if (!playerWeapon) return;
            playerWeapon.shotgunBonus = true;
        }
    }
}
