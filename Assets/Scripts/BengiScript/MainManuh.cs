using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject winImage;

    void Start()
    {
        
        if (PlayerPrefs.GetInt("HasWon") == 1)
        {
            MusicManager.instance.StopMusic();
            ShowWinImage();
            PlayerPrefs.SetInt("HasWon", 0);
        }
    }

    public void ShowWinImage()
    {
        if (winImage != null)
        {
            winImage.SetActive(true);
        }       
    }
}
