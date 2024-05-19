using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeToSurvive = 10f; 
    private float timer;
    private bool gameStarted;
    private int activeSceneIndex = 1;

    void Start()
    {
        Debug.Log("ge�ti");
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        timer = 0f;
        gameStarted = true; 
        Debug.Log("Oyun Ba�lad�");
    }

    void Update()
    {
        if (gameStarted)
        {
            timer += Time.deltaTime;
           // Debug.Log("Zamanlay�c�  okito");

            if (timer >= timeToSurvive)
            {
                
                int nextSceneIndex = activeSceneIndex + 1;

                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    Debug.Log("Sonraki sahne bulunamad�. Mevcut son sahnedesiniz.");
                }
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log("Sahne Y�kleniyor: " + sceneName);
        SceneManager.LoadScene(sceneName);
        MusicManager.instance.PlayMusic();
    }

    public void QuitGame()
    {
        Debug.Log("OMG oyundan ��kt�k");
        Application.Quit();
    }
}
