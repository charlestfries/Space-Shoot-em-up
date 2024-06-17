using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public static float secondsCount = 0f;
    public static int minuteCount = 0;

    void FixedUpdate()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        //Have the time set to the time spent in game
        secondsCount += Time.deltaTime;

        //When we reach 60 seconds add a minute
        if (secondsCount >= 59)
        {
            minuteCount++;
            secondsCount = 0;
        }

        //Format timer to have a 0 in front of colon if below 9 seconds
        if (secondsCount < 9)
        {
            timerText.text = minuteCount + ":0" + secondsCount.ToString("F0");
        }
        else if (secondsCount >= 10 && secondsCount < 60)
        {
            timerText.text = minuteCount + ":" + secondsCount.ToString("F0");
        }
    }

    public static void RestartTimer()
    {
        secondsCount = 0;
        minuteCount = 0;
    }
}
