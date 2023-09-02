using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSystem : MonoBehaviour
{
    public Sound[] sounds;

    private static SoundSystem instance;
    public static SoundSystem Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }

        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        PlayMusicOnSceneStart();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0) 
        {
            StopAllMusic();
        }
        PlayMusicOnSceneStart();
    }

    private void PlayMusicOnSceneStart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            PlaySound("MenuMusic");
        }
        else
        {
            PlaySound("Music");
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = System.Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            sound.audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound with name " + name + " not found!");
        }
    }

    public void StopAllMusic()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.audioSource.isPlaying)
            {
                sound.audioSource.Stop();
            }
        }
    }
}
