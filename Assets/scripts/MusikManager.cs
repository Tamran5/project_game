using UnityEngine;
using UnityEngine.SceneManagement;

public class MusikManager : MonoBehaviour
{
    private static MusikManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Mulai main musik
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            // Sudah ada instance → destroy duplikat
            Destroy(gameObject);
            return;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1" || scene.name == "Level2")
        {
            // Hentikan musik saat masuk level
            if (audioSource != null)
                audioSource.Stop();
        }
        else if (scene.name == "mainmenu" || scene.name == "LevelSelect")
        {
            // Lanjutkan musik tanpa restart
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}