using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUp : MonoBehaviour
{
    // Variables
    public float timer = 0f;
    public TMP_Text timerCount;

    void Update()
    {
        UpdateTimer();

        timer += Time.deltaTime;
    }

    void UpdateTimer()
    {
        timerCount.text = "Time Up " + Mathf.Floor(timer).ToString();
    }
}
