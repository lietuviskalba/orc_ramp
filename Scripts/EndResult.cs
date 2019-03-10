using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndResult : MonoBehaviour
{
    public Text txtShowScore;

    private int finalScore = 0;

    private void Start()
    {
        finalScore = PlayerPrefs.GetInt("Score"); // Get score before death
        txtShowScore.text = "Your Score \n" + finalScore.ToString(); //Display score
    }
}
