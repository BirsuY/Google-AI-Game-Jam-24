using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    [SerializeField] float winTime = 30f;
    private float timer = 0f;
    private bool gameWon = false;

    void Update()
    {
        if (!gameWon)
        {
            timer += Time.deltaTime;
            if (timer >= winTime)
            {
                gameWon = true;
                PlayerPrefs.SetInt("HasWon", 1); // Kazanma durumunu kaydedin
                SceneManager.LoadScene("MainManu"); // Ana menü sahnesine geçiþ yapýn
            }
        }
    }
}