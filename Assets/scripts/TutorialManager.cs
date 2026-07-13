using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject pauseButton;
    public GameObject speedPanel;

    void Start()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);

        // Sembunyikan saat tutorial
        if (pauseButton != null) pauseButton.SetActive(false);
        if (speedPanel != null) speedPanel.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MulaiGame()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;

        // Tampilkan setelah tutorial selesai
        if (pauseButton != null) pauseButton.SetActive(true);
        if (speedPanel != null) speedPanel.SetActive(true);
    }
}