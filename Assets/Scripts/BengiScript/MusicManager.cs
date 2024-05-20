using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private AudioSource[] audioSources;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
            audioSources = GetComponents<AudioSource>();
            PlayMusic();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // Ba�ka bi instance varsa bunu yok etmek i�in kullan�l�yo
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopMusic();
    }


    public void PlayMusic()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public void StopMusic()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

  //  public void ToggleSound() //ses a��p kapama
  //  {
  //      foreach (AudioSource audioSource in audioSources)
  //      {
  //          if (audioSource.isPlaying)
  //          {
  //              audioSource.Stop();
  //          }
  //          else
  //          {
  //              audioSource.Play();
  //          }
  //      }
  // 
  // 
  //  }
}
