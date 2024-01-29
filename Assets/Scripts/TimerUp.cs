using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUp : MonoBehaviour
{

    public float timer = 0f;

    public TMP_Text timerCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
