using UnityEngine;

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
        }
        else
        {
            Destroy(gameObject); // Ba�ka bi instance varsa bunu yok etmek i�in kullan�l�yo
        }
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
            audioSource.Stop();
        }
    }
}
