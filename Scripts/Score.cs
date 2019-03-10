using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject levelUI;
    private GameObject score;
    private Text txtScore;

    public int IncScoreGS { get; set; }

    void Start()
    {
        score = levelUI.transform.Find("Score").gameObject;
        txtScore = score.GetComponentInChildren<Text>();
        txtScore.text = ": 00"; // Set default txt
        IncScoreGS = 0; // Reset score
    }

    void Update()
    {
        txtScore.text = ": " + IncScoreGS.ToString("00"); // Display text
        PlayerPrefs.SetInt("Score", IncScoreGS); // Set score for end game
    }
}
