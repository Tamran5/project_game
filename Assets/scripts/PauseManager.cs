using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject timerObject;
    public GameObject gameOverPanel; // tambah ini
    private bool isPaused = false;

    void Update()
    {

    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        pausePanel.SetActive(isPaused);
        if (timerObject != null)
            timerObject.SetActive(!isPaused);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        if (timerObject != null)
            timerObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    // Dipanggil oleh GameTimer saat waktu habis
    public void WaktuHabis()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        if (timerObject != null)
            timerObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void KeLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}