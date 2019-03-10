using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject levelUI;
    private GameObject pausePanelUI;

    public static bool isPausedPressed;
    public static bool isItNowPaused;

    private void Start()
    {
        pausePanelUI = levelUI.transform.Find("Pause panel UI").gameObject;
        PauseParameters(false, 1);
    }

    public void ItsPausedClick()
    {
        PauseParameters(true, 0);
    }

    public void ItsResumedClick()
    {
        PauseParameters(false, 1);
    }

    private void PauseParameters(bool state, int time)
    {
        pausePanelUI.SetActive(state);
        Time.timeScale = time;
    }
}
