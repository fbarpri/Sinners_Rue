using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip drinkMusic;

    private AudioSource source;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (source.clip == clip) return;

        source.clip = clip;
        source.Play();
    }

    public void PlayMenu()
    {
        PlayMusic(menuMusic);
    }

    public void PlayGame()
    {
        PlayMusic(gameMusic);
    }

    public void PlayDrink()
    {
        PlayMusic(drinkMusic);
    }
}