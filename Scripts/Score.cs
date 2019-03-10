using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject score;
    private Text txtScore;

    public int IncScoreGS { get; set; }

    void Start()
    {
        txtScore = score.GetComponentInChildren<Text>();
        txtScore.text = ": 00"; // Set default txt
    }

    void Update()
    {
        txtScore.text = ": " + IncScoreGS.ToString("00"); // Display text
    }
}
