using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreCounter : MonoBehaviour
{private int Score;
    private String Score_Text; 

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void incrementScore(){
        Score++;
        Score_Text = Score.ToString();
        gameObject.ConvertTo<TMP_Text>().text = Score_Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            incrementScore();
        }

    }
    

}
