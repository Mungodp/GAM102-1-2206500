using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text flowersText;

    [SerializeField] private TMP_Text timerText;
    [SerializeField, GradientUsage(false)] private Gradient gradient;

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject pausedScreen;
    
    public static UIManager instance { get; private set; }
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
    public void SetFlowersText(string text)
    {
        flowersText.text = text;
    }

    public void SetTime(float time)
    {
        if (time <= 0)
        {
            timerText.text = $"00<size=85%>:<size=70%>00";
            GameManager.instance.GameOver(loseScreen);
            return;
        }
        
        int cSeconds = (int)(Mathf.Floor(time * 100) - Mathf.Floor(time) * 100);
        int seconds = (int)time;

        var cSecondsString = cSeconds < 10 ? "0" + cSeconds : cSeconds.ToString();
        var secondsString = seconds < 10 ? "0" + seconds : seconds.ToString();

        timerText.text = $"{secondsString}<size=85%>:<size=70%>{cSecondsString}";
        timerText.color = gradient.Evaluate(1 - (time / 60));
    }

    public void WinGame()
    {
        GameManager.instance.GameOver(winScreen);
    }

    public void Resume()
    {
        pausedScreen.SetActive(false);
    }
    
    public void Pause()
    {
        pausedScreen.SetActive(true);
    }
}
