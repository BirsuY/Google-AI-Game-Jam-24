using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
   
    public float timeRemaining = 30f; // Ba�lang�� zaman�
    public Text countdownText; // UI Text bile�eni referans�

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
            // Zaman bitti�inde yap�lacaklar
            countdownText.text = "0:00";
            // �rne�in, sahneyi yeniden y�klemek i�in:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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


