using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
   
    public float timeRemaining = 30f;
    public Text countdownText; // UI Text bileþeni referansý

    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("Countdown Text is not assigned.");
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            countdownText.text = "0:00";           
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}


